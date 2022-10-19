using Core.Entities.Bookings;
using SharedKernel.Bases;
using SharedKernel.Enums;
using SharedKernel.Exceptions;

namespace Core.Entities;

public class Interview : ModifyEntity
{
  private Interview() { } //ef constructor

  public Interview(DateTime start, DateTime end)
  {
    StartTime = start;
    EndTime = end;
    
  }

  public DateTime JoinStartTime { get; private set; }
  public DateTime JoinEndTime { get; private set; }
  public DateTime EndTime { get; private set; }
  public DateTime StartTime { get; private set; }
  public int BookingId { get; private set; }
  public virtual Booking? Booking { get; set; }

  public virtual InterviewResult? Result { get; set; }

  public static Interview Setup(DateTime startTime, DateTime endTime)
  {
    return new Interview
    {
      StartTime = startTime,
      EndTime = endTime
    };
  }

  public void ChangeTime(DateTime start, DateTime end)
  {
    int compareStartToEndTime = start.CompareTo(end);

    if (compareStartToEndTime > 0)
      throw new InvalidTimeException($"{start} cannot later than {end}");

    if (compareStartToEndTime == 0)
      throw new InvalidTimeException($"{start} cannot equal to {end}");

    StartTime = start;
    EndTime = end;
  }

  public void Start()
  {
    JoinStartTime = DateTime.Now;
    Status = Status.OnProcessing;
  }

  public void Finish()
  {
    JoinEndTime = DateTime.Now;
    Status = Status.Done;
  }

  public void EvaluateCandidate(InterviewResult result)
  {
    if (Status != SharedKernel.Enums.Status.Done)
      throw new InvalidTimeException($"cannot evaluate when not interview");

    Result = result;
  }
}