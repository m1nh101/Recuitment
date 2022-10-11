using AutoMapper;
using Core.CQRS.Bookings.Requests;
using Core.CQRS.Bookings.Respones;
using Core.CQRS.Responses;
using Core.Entities;
using Core.Entities.Bookings;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Bookings.Handlers;

public class CreateBookingRequestHandler : IRequestHandler<CreateNewBookingRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public CreateBookingRequestHandler(IAppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(CreateNewBookingRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications.FirstOrDefaultAsync(e => e.Id == request.ApplicationId, cancellationToken);

    if (application == null)
      return new NotFoundResponse();

    var interview = Interview.Setup(request.Start, request.End);

    var booking = Booking.Create(request.Date, request.Note,
      request.Place, request.MeetingUrl, 
      request.MeetingType, request.ReviewerId, interview);

    application.BookingInterview(booking);

    _context.Applications.Update(application);
    
    await _context.Commit();

    var response = _mapper.Map<GeneralBookingResponse>(booking);

    return new SuccessResponse("Tạo lịch phỏng vấn thành công", response);
  }
}