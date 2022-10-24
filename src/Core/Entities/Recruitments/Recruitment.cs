using SharedKernel.Bases;

namespace Core.Entities.Recruitments;

public partial class Recruitment : ModifyEntity
{
  private Recruitment() { }

  public Recruitment(string name, string content, string benifit, DateTime startDate,
    DateTime endDate, int salaryMin, int salaryMax, int experienceFrom, int experienceTo,
    int number, int positionId, int departmentId)
  {
    Name = name;
    Content = content;
    Benifit = benifit;
    StartDate = startDate;
    EndDate = endDate;
    SalaryMin = salaryMin;
    SalaryMax = salaryMax;
    ExperienceFrom = experienceFrom;
    ExperienceTo = experienceTo;
    Number = number;
    PositionId = positionId;
    DepartmentId = departmentId;
  }

  public string Name { get; private set; } = string.Empty;
  public string Content { get; private set; } = string.Empty;
  public string Benifit { get; private set; } = string.Empty;
  public DateTime StartDate { get; private set; }
  public DateTime EndDate { get; private set; }
  public int SalaryMin { get; private set; }
  public int SalaryMax { get; private set; }
  public int ExperienceFrom { get; private set; }
  public int ExperienceTo { get; private set; }
  public int Number { get; private set; }
  public int PositionId { get; private set; }
  public int DepartmentId { get; private set; }

  public virtual Department? Department { get; set; }
  public virtual Position? Position { get; set; }
  public virtual ICollection<RecruitSkillTag>? SkillTags { get; set; }
}