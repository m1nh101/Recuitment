using SharedKernel.Bases;

namespace Core.Entities;

public class Recruitment : ModifyEntity
{
  public string Name { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string Benifit { get; set; } = string.Empty;
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public int SalaryMin { get; set; }
  public int SalaryMax { get; set; }
  public int ExperienceFrom { get; set; }
  public int ExperienceTo { get; set; }
  public int Number { get; set; }
  public int PositionId { get; set; }
  public int DepartmentId { get; set; }

  public virtual Department? Department { get; set; }
  public virtual Position? Position { get; set; }
  public virtual ICollection<RecruitSkillTag>? SkillTags { get; set; }
  public virtual ICollection<Candidate>? Candidates { get; set; }
}

