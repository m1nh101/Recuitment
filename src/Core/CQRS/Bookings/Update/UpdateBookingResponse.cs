namespace Core.CQRS.Bookings.Update;

public sealed record UpdateBookingResponse(
  DateTime Date,
  DateTime Start,
  DateTime End,
  string ReviewerName
);