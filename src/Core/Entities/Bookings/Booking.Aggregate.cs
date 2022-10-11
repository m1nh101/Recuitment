using SharedKernel.Enums;

namespace Core.Entities.Bookings;

public partial class Booking
{
  public static Booking Create(DateTime date, string note,
    string place, string meetingUrl, MeetingType meetingType, string reviewerId, Interview? interview)
  {
    return new Booking
    {
      Date = date,
      Note = note,
      Place = place,
      MeetingUrl = meetingUrl,
      MeetingType = meetingType,
      ReviewerId = reviewerId,
      Interview = interview
    };
  }

  public void Cancel() => Status = Status.Cancel;
}