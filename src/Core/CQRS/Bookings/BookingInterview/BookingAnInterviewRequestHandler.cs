using AutoMapper;
using Core.CQRS.Responses;
using Core.Entities;
using Core.Entities.Bookings;
using Core.Entities.Users;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Bookings.BookingInterview;

public sealed class BookingAnInterviewRequestHandler
  : IRequestHandler<BookingAnInterviewRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;
  private readonly UserManager<User> _userManager;

  public BookingAnInterviewRequestHandler(IAppDbContext context, IMapper mapper,
    UserManager<User> userManager)
  {
    _context = context;
    _mapper = mapper;
    _userManager = userManager;
  }

  public async Task<ActionResponse> Handle(BookingAnInterviewRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications.FirstOrDefaultAsync(e => e.Id == request.ApplicationId, cancellationToken);
    var reviewer = await _userManager.FindByIdAsync(request.ReviewerId);

    bool isInvalidRequest = application == null || reviewer == null;
    
    if (isInvalidRequest)
      return new NotFoundResponse();

    var interview = Interview.Setup(request.Start, request.End);

    var booking = Booking.Create(request.Date, string.Empty,
      "Office", string.Empty, 
      SharedKernel.Enums.MeetingType.Offline, request.ReviewerId, interview);

    application!.BookingInterview(booking);

    _context.Applications.Update(application);
    
    await _context.Commit();

    var response = new BookingAnInterviewResponse(request.Date, request.Start, request.End, reviewer!.Name, booking.Id);

    return new SuccessResponse("Tạo lịch phỏng vấn thành công", response);
  }
}
