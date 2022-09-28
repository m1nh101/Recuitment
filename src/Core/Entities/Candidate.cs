using SharedKernel.Bases;
using SharedKernel.Enums;

namespace Core.Entities;

public class Candidate : ModifyEntity
{
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public string Attachment { get; set; } = string.Empty;
  public string Qualification { get; set; } = string.Empty;
  public Gender Gender { get; set; }
  public DateTime Birthday { get; set; }
  public string Note { get; set; } = string.Empty;
  public int RecruitmentId { get; set; }

  public virtual Recruitment? Recruitment { get; set; }
  public virtual ICollection<CandidateSkillTag>? SkillTags { get; set; }
  public virtual ICollection<Booking>? Bookings { get; set; }
  public virtual ICollection<InterviewResult>? InterviewResults { get; set; }
}

