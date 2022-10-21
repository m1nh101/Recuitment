namespace Core.CQRS.Recruitments.Query;

public record RecruitmentDetailResponse(
  int Id,
  string Name,
  string Content,
  string Benifit,
  int SalaryMinx,
  int SalaryMax,
  int ExperienceFrom,
  int ExperienceTo,
  int Number,
  IEnumerable<ApplicationAppliedInRecruitment> Applications
);
