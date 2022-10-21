using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Applications.Apply;

public sealed class ApplyToRecruitmentRequestHandler
  : IRequestHandler<ApplyToRecruitmentRequest, ActionResponse>
{
    public Task<ActionResponse> Handle(ApplyToRecruitmentRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}