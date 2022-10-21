using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Bookings.Cancel;

public sealed record CancelBookingRequest(
  int ApplicationId
) : IRequest<ActionResponse>;