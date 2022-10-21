using Core.CQRS.Responses;
using Core.Entities.Users;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Bookings.Update;

public sealed record UpdateBookingRequest(
  int ApplicationId,
  DateTime Date,
  DateTime Start,
  DateTime End,
  string ReviewerId
) : IRequest<ActionResponse>;

public sealed class UpdateBookingRequestHandler
  : IRequestHandler<UpdateBookingRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly UserManager<User> _userManager;

  public UpdateBookingRequestHandler(IAppDbContext context, UserManager<User> userManager)
  {
    _context = context;
    _userManager = userManager;
  }

  public async Task<ActionResponse> Handle(UpdateBookingRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications
      .Include(e => e.Booking)
      .FirstOrDefaultAsync(e => e.Id == request.ApplicationId);

    if(request.ReviewerId != application.Booking!.ReviewerId)
    throw new NotImplementedException();
  }
}
