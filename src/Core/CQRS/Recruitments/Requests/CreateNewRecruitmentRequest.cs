using Core.CQRS.Recruitments.Responses;
using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;
public sealed record CreateNewRecruitmentRequest(
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