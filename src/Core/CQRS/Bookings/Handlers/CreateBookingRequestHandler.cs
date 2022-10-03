using AutoMapper;
using Core.CQRS.Bookings.Requests;
using Core.CQRS.Bookings.Respones;
using Core.CQRS.Responses;
using Core.Entities.Bookings;
using Core.Interfaces;
using MediatR;

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
    var booking = Booking.Create(request);

    await _context.Bookings.AddAsync(booking, cancellationToken);
    await _context.Commit();

    var response = _mapper.Map<GeneralBookingResponse>(booking);

    return new SuccessResponse("Tạo lịch phỏng vấn thành công", response);
  }
}