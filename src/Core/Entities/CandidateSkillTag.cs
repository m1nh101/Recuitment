using SharedKernel.Bases;

namespace Core.Entities;

public class CandidateSkillTag : BaseEntity
{
  public decimal Number { get; set; }
  public int CandidateId { get; set; }
  public int SkillTagId { get; set; }

  public virtual SkillTag? SkillTag { get; set; }
  public virtual Candidate? Candidate { get; set; }
}