using Core.CQRS.Bookings.Requests;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Bookings.Handlers;

public class CancelBookingInterviewRequestHandler : IRequestHandler<CancelBookingInterviewRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public CancelBookingInterviewRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(CancelBookingInterviewRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications
      .Include(e => e.Booking)
      .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

    if(application == null)
      return new NotFoundResponse();

    application.Booking!.Cancel();

    _context.Applications.Update(application);

    await _context.Commit();

    return new SuccessResponse("Huỷ lịch phỏng vấn thành công", null);
  }
}