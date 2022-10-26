using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Applications.Detail;

public sealed record GetApplicationDetailRequest(
  int ApplicationId
) : IRequest<ActionResponse>;