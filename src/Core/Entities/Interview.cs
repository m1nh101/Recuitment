using SharedKernel.Bases;

namespace Core.Entities;

public class Interview : ModifyEntity
{
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public DateTime StartTime { get; set; }
  public DateTime EndTime { get; set; }
  public DateTime JoinStartTime { get; set; }
  public DateTime JoinEndTime { get; set; }

  public int BookingId { get; set; }
  public virtual Booking? Booking { get; set; }

  public virtual InterviewResult? Result { get; set; }
}

