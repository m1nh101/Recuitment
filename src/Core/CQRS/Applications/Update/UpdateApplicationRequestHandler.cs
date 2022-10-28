using AutoMapper;
using Core.CQRS.Responses;
using Core.Entities;
using Core.Entities.Bookings;
using Core.Entities.Recruitments;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Applications.Update;

public sealed class UpdateApplicationRequestHandler
  : IRequestHandler<UpdateApplicationRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public UpdateApplicationRequestHandler(IAppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(UpdateApplicationRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications
      .Include(e => e.Candidate)
      .Include(e => e.Booking!)
      .ThenInclude(e => e.Interview!)
      .ThenInclude(e => e.Result)
      .FirstOrDefaultAsync(e => e.Id == request.ApplicationId, cancellationToken);

    if (application == null)
      throw new NullReferenceException();

    if (request.InterviewTime != null)
    {
      HandleBookingUpdate(application, request.InterviewTime);

      if (request.Review != null)
      {
        var interviewResult = application.Booking!.Interview!.Result;
        var review = HandleReviewUpdate(interviewResult, request.Review);
        application.Booking!.Interview!.EvaluateCandidate(review);
      }
    }

    _context.Applications.Update(application);

    await _context.Commit();

    return new SuccessResponse("Lưu thay đổi thành công", null);
  }

  private static void HandleBookingUpdate(Application application, InterviewTimePayload payload)
  {
    if (application.Booking == null)
    {
      var interview = Interview.Setup(payload.Start, payload.End);

      var booking = Booking.Create(payload.Date, string.Empty, "Office",
        string.Empty, SharedKernel.Enums.MeetingType.Offline, payload.ReviewerId, interview);

      application.BookingInterview(booking);
    } else
      application.Booking.Update(payload.Start, payload.ReviewerId, payload.Start, payload.End);
  }
  private InterviewResult HandleReviewUpdate(InterviewResult? result, ReviewInterviewPayload payload)
  {
    var evaluable = _mapper.Map<InterviewResult>(payload);

    return evaluable;
  }
}