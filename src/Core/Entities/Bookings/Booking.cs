using Core.Entities.Recruitments;
using SharedKernel.Bases;
using SharedKernel.Enums;

namespace Core.Entities.Bookings;

public partial class Booking : ModifyEntity
{
  private Booking()
  {
  }

  public Booking(DateTime date, string note,
    string place, string meetingUrl, MeetingType meetingType,
    string reviewerId, Interview? interview)
  {
    Date = date;
    Note = note;
    Place = place;
    MeetingUrl = meetingUrl;
    MeetingType = meetingType;
    ReviewerId = reviewerId;
    Interview = interview;
  }

  public string Name { get; private set; } = string.Empty;
  public DateTime Date { get; private set; }
  public string Note { get; private set; } = string.Empty;
  public string Place { get; private set; } = string.Empty;
  public string MeetingUrl { get; private set; } = string.Empty;
  public MeetingType MeetingType { get; private set; }
  public string ReviewerId { get; private set; } = string.Empty;
  public int ApplicationId { get; private set; }

  public virtual Application? Application { get; set; }
  public virtual Interview? Interview { get; set; }
}