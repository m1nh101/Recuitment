using SharedKernel.Enums;

namespace Core.CQRS.Recruitments.Query;

public record ApplicationAppliedInRecruitment(
  int Id,
  string Name,
  Gender Gender,
  string Email,
  string Phone,
  string Address,
  Status Status
);
