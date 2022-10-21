using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Query;

public sealed record GetRecruitmentDetailRequest(
  int Id
) : IRequest<ActionResponse>;
