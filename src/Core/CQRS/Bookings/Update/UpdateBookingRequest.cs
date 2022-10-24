using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Bookings.Update;

public sealed record UpdateBookingRequest(
  int ApplicationId,
  DateTime Date,
  DateTime Start,
  DateTime End,
  string ReviewerId
) : IRequest<ActionResponse>;