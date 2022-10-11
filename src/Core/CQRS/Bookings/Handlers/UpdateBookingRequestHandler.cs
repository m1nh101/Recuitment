using AutoMapper;
using Core.CQRS.Bookings.Requests;
using Core.CQRS.Bookings.Respones;
using Core.CQRS.Responses;
using Core.Entities.Bookings;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Bookings.Handlers;

public class UpdateBookingRequestHandler : IRequestHandler<UpdateBookingRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public UpdateBookingRequestHandler(IAppDbContext context,
    IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(UpdateBookingRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications
      .Include(e => e.Booking)
      .ThenInclude(e => e!.Interview)
      .FirstOrDefaultAsync(e => e.Id == request.ApplicationId, cancellationToken);

    if (application == null)
      return new NotFoundResponse();

    var booking = Booking.Create(request.Date, request.Note, request.Place, 
      request.MeetingUrl, request.MeetingType, request.ReviewerId, null);

    var bookingId = application.Booking!.Id;

    application.BookingInterview(booking, bookingId);

    application.Booking!.Interview!.ChangeTime(request.Start, request.End);

    _context.Applications.Update(application);

    await _context.Commit();

    var response = _mapper.Map<GeneralBookingResponse>(booking);

    return new SuccessResponse("Cập nhật dữ liệu thành công", response);
  }
}