using Core.CQRS.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Core.CQRS.Interviews.Finnish;

public sealed record FinishInterviewRequest(
  int ApplicationId,
  InterviewEvaluate Result
) : IRequest<ActionResponse>;

public sealed record InterviewEvaluate(
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