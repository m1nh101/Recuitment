using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Bookings.Cancel;

public sealed class CancelInterviewRequestHandler
  : IRequestHandler<CancelBookingRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public CancelInterviewRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(CancelBookingRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications
      .Include(e => e.Booking)
      .FirstOrDefaultAsync(e => e.Id == request.ApplicationId);

    if(application == null)
      throw new NullReferenceException();

    application.Booking!.Cancel();

    return new SuccessResponse("Hủy lịch phỏng vấn thành công", null);
  }
}