using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Candidates.Requests;

public class GetCandidateDetailRequest : IRequest<ActionResponse>
{
	public GetCandidateDetailRequest(int id, int recruitmentId)
	{
		Id = id;
		RecruitmentId = recruitmentId;
	}

  public int Id { get; }
	public int RecruitmentId { get; }
}