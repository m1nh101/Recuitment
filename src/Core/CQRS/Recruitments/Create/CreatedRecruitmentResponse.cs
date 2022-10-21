namespace Core.CQRS.Recruitments.Create;

public record CreatedRecruitmentResponse(
  int Id,
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