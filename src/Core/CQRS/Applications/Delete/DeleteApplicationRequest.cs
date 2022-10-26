using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Applications.Delete;

public sealed record DeleteApplicationRequest(
  int RecruitmentId,
  int ApplicationId) : IRequest<ActionResponse>;