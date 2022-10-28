using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Applications.Update;

public sealed record InterviewTimePayload(
  DateTime Date,
  DateTime Start,
  DateTime End,
  string ReviewerId);

public sealed record ReviewInterviewPayload(
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

public sealed record UpdateApplicationRequest(
  int ApplicationId,
  string? Attachment,
  InterviewTimePayload? InterviewTime,
  ReviewInterviewPayload? Review) : IRequest<ActionResponse>;