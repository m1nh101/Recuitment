using Core.Entities.Recruitments;

namespace Core.CQRS.Recruitments.Responses;

public class ListRecruitmentResponse
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public int SalaryMin { get; set; }
  public int SalaryMax { get; set; }
  public int ExperienceFrom { get; set; }
  public int ExperienceTo { get; set; }
  public int Number { get; set; }

  public static ListRecruitmentResponse ConvertFrom(Recruitment source)
  {
    return new ListRecruitmentResponse
    {
      Id = source.Id,
      StartDate = source.StartDate,
      EndDate = source.EndDate,
      SalaryMax = source.SalaryMax,
      SalaryMin = source.SalaryMin,
      ExperienceFrom = source.ExperienceFrom,
      ExperienceTo = source.ExperienceTo,
      Number = source.Number,
      Name = source.Name
    };
  }
}