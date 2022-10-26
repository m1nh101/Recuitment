using SharedKernel.Enums;

namespace Core.CQRS.Candidate.Get;

public sealed record CandidateResponse(
  int Id,
  string Name,
  string Address,
  string Qualification,
  DateTime Birthday,
  Gender Gender
);
