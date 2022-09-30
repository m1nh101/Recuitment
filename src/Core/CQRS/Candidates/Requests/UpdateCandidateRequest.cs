using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Candidates.Requests;

public class UpdateCandidateRequest : AddCandidateToRecruitmentRequest, IRequest<ActionResponse>
{
  public int Id { get; set; }
}