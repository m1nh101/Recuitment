using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Positions.Requests;

public class GetAllPositionsRequest : IRequest<ActionResponse>
{
}