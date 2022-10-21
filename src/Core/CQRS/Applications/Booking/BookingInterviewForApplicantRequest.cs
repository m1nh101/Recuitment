using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Applications.Booking;

public sealed record BookingInterviewForApplicantRequest(
  int ApplicationId,
  DateTime Date,
  DateTime StartTime,
  DateTime EndTime,
  string Reviewer
) : IRequest<ActionResponse>;