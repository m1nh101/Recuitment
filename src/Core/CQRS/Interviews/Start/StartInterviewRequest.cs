using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Interviews;

public sealed record StartInterviewRequest(
  int ApplicationId
) : IRequest<ActionResponse>;