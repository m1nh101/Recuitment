using Core.CQRS.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Core.CQRS.Bookings.Requests;

public class CreateNewBookingRequest : IRequest<ActionResponse>
{
  public string Name { get; set; } = string.Empty;
  public DateTime Date { get; set; }
  public string Note { get; set; } = string.Empty;
  public string Place { get; set; } = string.Empty;
  public string MeetingUrl { get; set; } = string.Empty;
  public MeetingType MeetingType { get; set; }
  public string ReviewerId { get; set; } = string.Empty;
  public int ApplicationId { get; set; }
  public DateTime Start { get; set; }
  public DateTime End { get; set; }
}