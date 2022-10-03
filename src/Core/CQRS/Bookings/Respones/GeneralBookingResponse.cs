using SharedKernel.Enums;

namespace Core.CQRS.Bookings.Respones;

public class GeneralBookingResponse
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public DateTime Date { get; set; }
  public string Note { get; set; } = string.Empty;
  public string Place { get; set; } = string.Empty;
  public string MeetingUrl { get; set; } = string.Empty;
  public MeetingType MeetingType { get; set; }
  public string ReviewerId { get; set; } = string.Empty;
  public int ApplicationId { get; set; }
}