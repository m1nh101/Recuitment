using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Bookings.BookingInterview;

public sealed record BookingAnInterviewRequest(
  int ApplicationId,
  DateTime Date,
  DateTime Start,
  DateTime End,
  string ReviewerId
) : IRequest<ActionResponse>;