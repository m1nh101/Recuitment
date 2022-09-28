using SharedKernel.Bases;
using SharedKernel.Enums;

namespace Core.Entities;

public class SkillTag : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public SkillTagType Type { get; set; }
  public virtual ICollection<RecruitSkillTag>? Recruiments { get; set; }
  public virtual ICollection<CandidateSkillTag>? Candidates { get; set; }
}