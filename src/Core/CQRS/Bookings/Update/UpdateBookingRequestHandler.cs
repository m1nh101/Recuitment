using Core.CQRS.Responses;
using Core.Entities.Users;
using Core.Exceptions;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Bookings.Update;

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
      .Include(e => e.Booking!)
      .ThenInclude(e => e.Interview)
      .FirstOrDefaultAsync(e => e.Id == request.ApplicationId);

    if(application == null)
      throw new NullReferenceException();

    var reviewer = await _userManager.FindByIdAsync(request.ReviewerId);
    if(reviewer == null)
      throw new InvalidUserException($"{request.ReviewerId} is invalid user id");

    application.Booking!.Update(request.Date, request.ReviewerId, request.Start, request.End);

    _context.Applications.Update(application);
    await _context.Commit();

    var response = new UpdateBookingResponse(request.Date, request.Start, request.End, reviewer.Name);

    return new SuccessResponse("Cập nhật lịch phỏng vấn thành công", response);
  }
}
