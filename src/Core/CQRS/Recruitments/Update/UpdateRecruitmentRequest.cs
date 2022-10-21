using Core.CQRS.Recruitments.Create;
using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Update;

public sealed record UpdateRecruitmentRequest(
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
) : IRequest<ActionResponse>;