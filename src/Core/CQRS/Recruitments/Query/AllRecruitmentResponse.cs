using SharedKernel.Enums;

namespace Core.CQRS.Recruitments.Query;

public record AllRecruitmentResponse(
  int Id,
  string Name,
  DateTime StartDate,
  DateTime EndDate,
  int SalaryMin,
  int SalaryMax,
  int ExperienceFrom,
  int ExperienceTo,
  int Number,
  Status Status
);
