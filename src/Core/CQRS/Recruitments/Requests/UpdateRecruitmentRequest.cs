using Core.CQRS.Candidates.Requests;
using Core.CQRS.Recruitments.Responses;
using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public class UpdateRecruitmentRequest : CreateNewRecruitmentRequest,
  IRequest<ActionResponse>
{
    public int Id { get; set; }
}