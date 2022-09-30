using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public class GetRecruitmentDetailRequest : IRequest<ActionResponse>
{
	public GetRecruitmentDetailRequest(int id)
	{
		Id = id;
	}

  public int Id { get; private set; }
}