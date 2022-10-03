using Core.Entities.Recruitments;
using SharedKernel.Bases;

namespace Core.Entities;

public class RecruitSkillTag : BaseEntity
{
  public decimal Number { get; set; }
  public int RecruitmentId { get; set; }
  public int SkillTagId { get; set; }

  public virtual Recruitment? Recruitment { get; set; }
  public virtual SkillTag? SkillTag { get; set; }
}