using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Create;

public record CreateRecruitmentRequest(
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
  int DepartmentId) : IRequest<ActionResponse>;