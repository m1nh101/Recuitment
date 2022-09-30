using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public class GetAllRecruitmentsRequest : IRequest<ActionResponse>
{
}