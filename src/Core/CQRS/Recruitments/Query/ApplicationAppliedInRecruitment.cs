using SharedKernel.Enums;

namespace Core.CQRS.Recruitments.Query;

public record ApplicationAppliedInRecruitment(
  int Id,
  string CandidateName,
  Gender Gender,
  string Email,
  string PhoneNumber
);
