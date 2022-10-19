using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Bookings.Requests;

public sealed record UpdateBookingRequest(
  int Id,
  CreateNewBookingRequest Payload) : IRequest<ActionResponse>;