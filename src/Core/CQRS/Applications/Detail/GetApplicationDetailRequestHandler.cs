using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Applications.Detail;

public sealed class GetApplicationDetailRequestHandler
  : IRequestHandler<GetApplicationDetailRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetApplicationDetailRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(GetApplicationDetailRequest request, CancellationToken cancellationToken)
  {
    BookingApplicationData? booking = null;
    InterviewData? interview = null;

    var application = await _context.Applications
      .Include(e => e.Candidate)
      .Include(e => e.Booking!)
      .ThenInclude(e => e.Interview!)
      .ThenInclude(e => e.Result)
      .AsNoTracking()
      .FirstOrDefaultAsync(e => e.Id == request.ApplicationId, cancellationToken);

    if(application == null)
      throw new NullReferenceException();

    var candidate = application.Candidate!;

    if(application.Booking != null)
      booking = new BookingApplicationData(application.Booking!.Date, application.Booking!.ReviewerId, application.Booking!.Status);

    if (application.Booking!.Status == SharedKernel.Enums.Status.BookedInterview)
      interview = new InterviewData(application.Booking!.Interview!.StartTime, application.Booking!.Interview!.EndTime, application.Booking!.Interview!.Status);

    var candidateData = new CandidateData(candidate.Name, candidate.Birthday, candidate.Gender,
      candidate.Address, candidate.Email);

    var response = new GetApplicationDetailResponse(candidateData, null ,application.Attachment, application.Status);

    return new SuccessResponse("Thành công", response);
  }
}