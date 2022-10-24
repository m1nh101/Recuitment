namespace Core.CQRS.Recruitments.Update;

public sealed record UpdateRecruitmentResponse(
  string Name,
  string Content,
  string Benifit,
  DateTime StartDate,
  DateTime EndDate,
  int SalaryMin,
  int SalaryMax,
  int ExperienceFrom,
  int ExperienceTo,
  int Number,
  int PositionId,
  int DepartmentId
);
