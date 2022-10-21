using Core.CQRS.Responses;
using MediatR;
using SharedKernel.Enums;

namespace Core.CQRS.Applications.Review;

public sealed record ReviewApplicationRequest(
  int ApplicationId,
  Status Status
) : IRequest<ActionResponse>;