using Core.CQRS.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Core.CQRS.Interviews.Requests;

public sealed record FinishInterviewRequest(
  int ApplicationId,
  ReviewCandidateResult? Payload
) : IRequest<ActionResponse>;

public sealed record ReviewCandidateResult(
  string Note,
  string Experience,
  string Skill,
  string ResolveProblem,
  string Attitude,
  string SelfLearning,
  string Desire,
  Status Overview,
  int SalaryFrom,
  int SalaryTo,
  int LevelId
);