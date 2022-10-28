using SharedKernel.Enums;

namespace Core.CQRS.Applications.Detail;

public sealed record GetApplicationDetailResponse(
  CandidateData Candidate,
  InterviewData? Booking,
  InterviewResultResponse? Result,
  Status Status
);

public sealed record CandidateData(
  string Name,
  DateTime Birthday,
  Gender Gender,
  string Address,
  string Email,
  string Attachment,
  string Qualification
);

public sealed record InterviewData(
  DateTime Date,
  DateTime Start,
  DateTime End,
  Status Status,
  string ReviewerId
);

public sealed record InterviewResultResponse(
  string Attitide,
  string SelfLearning,
  string Skill,
  string ResolveProblem,
  string Desire,
  string Experience,
  int SalaryMin,
  int SalaryMax,
  string Note,
  int LevelId);