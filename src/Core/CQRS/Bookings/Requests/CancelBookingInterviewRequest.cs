using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Bookings.Requests;

public class CancelBookingInterviewRequest : IRequest<ActionResponse>
{
  public int Id { get; set; } //application id
}