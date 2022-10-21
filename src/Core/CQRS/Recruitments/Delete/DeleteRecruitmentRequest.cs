using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Delete;

public sealed record DeleteRecruitmentRequest(
  int Id
) : IRequest<ActionResponse>;
