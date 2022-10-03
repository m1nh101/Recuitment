using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public class DeleteCandidateFromRecruitmentRequest : IRequest<ActionResponse>
{
  public int RecruitmentId { get; set; }
  public int CandidateId { get; set; }
}