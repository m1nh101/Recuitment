using Core.Entities.Bookings;
using Core.Entities.Candidates;
using SharedKernel.Bases;

namespace Core.Entities.Recruitments;

public class Application : ModifyEntity
{
  private Application() { }

  public Application(int candidateId, string attachment)
  {
    CandidateId = candidateId;
    Attachment = attachment;
  }

  public Application(Candidate candidate, string attachment)
  {
    Candidate = candidate;
    Attachment = attachment;
  }

  public int CandidateId { get; set; }
  public int RecruitmentId { get; set; }

  public string Attachment { get; private set; } = string.Empty;

  public virtual Candidate? Candidate { get; private set; }
  public virtual Recruitment? Recruitment { get; private set; }
  public virtual Booking? Booking { get; set; }

  public void UpdateAttachment(string attachment) => Attachment = attachment;
}