using Core.CQRS.Bookings.Requests;

namespace Core.Entities.Bookings;

public partial class Booking
{
  public static Booking Create(CreateNewBookingRequest request)
  {
    return new Booking
    {
      Name = request.Name,
      Date = request.Date,
      MeetingType = request.MeetingType,
      Place = request.Place,
      MeetingUrl = request.MeetingUrl,
      Note = request.Note,
      ReviewerId = request.ReviewerId,
      ApplicationId = request.ApplicationId,
    };
  }
  public void Update() { }
  public void Cancel() => Status = SharedKernel.Enums.Status.Cancel;

  public void StartInterview()
  {

  }
}