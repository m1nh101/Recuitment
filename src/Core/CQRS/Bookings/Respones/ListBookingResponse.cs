namespace Core.CQRS.Bookings.Respones;

public class ListBookingResponse
{
  public int Id { get; set; }
  public string CandidateName { get; set; } = string.Empty;
  public string Position { get; set; } = string.Empty;
  public string RecruitmentTitle { get; set; } = string.Empty;
  public DateTime Start { get; set; }
  public DateTime End { get; set; }

}