namespace Core.CQRS.Bookings.BookingInterview;

public sealed record BookingAnInterviewResponse(
  DateTime Date,
  DateTime Start,
  DateTime End,
  string ReviewerName,
  int BookingId
);