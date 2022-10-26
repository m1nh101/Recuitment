namespace Core.CQRS.Recruitments.Query;

public record RecruitmentDetailResponse(
  int Id,
  string Name,
  string Content,
  string Benifit,
  int SalaryMin,
  int SalaryMax,
  int ExperienceFrom,
  int ExperienceTo,
  int Number,
  DateTime StartDate,
  DateTime EndDate,
  int PositionId,
  int DepartmentId,
  IEnumerable<ApplicationAppliedInRecruitment> Applications
);
