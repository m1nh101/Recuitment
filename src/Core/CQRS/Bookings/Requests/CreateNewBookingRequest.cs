using Core.CQRS.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Core.CQRS.Bookings.Requests;

public sealed record CreateNewBookingRequest(
  string Name,
  DateTime Date,
  string Note,
  string Place,
  MeetingType MeetingType,
  string ReviewerId,
  int ApplicationId,
  DateTime Start,
  DateTime End) : IRequest<ActionResponse>;