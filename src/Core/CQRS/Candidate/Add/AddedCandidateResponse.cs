using SharedKernel.Enums;

namespace Core.CQRS.Candidate.Add;

public sealed record AddedCandidateResponse(
  string Name,
  string Email,
  string Phone,
  DateTime Birthday,
  string Address,
  Gender Gender,
  string Qualification,
  int RecruitmentId,
  int Id,
  string Attachment
);
