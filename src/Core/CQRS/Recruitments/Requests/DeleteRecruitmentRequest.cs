using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public class DeleteRecruitmentRequest : IRequest<ActionResponse>
{
	public DeleteRecruitmentRequest(int id)
	{
		Id = id;
	}

  public int Id { get; private set; }
}