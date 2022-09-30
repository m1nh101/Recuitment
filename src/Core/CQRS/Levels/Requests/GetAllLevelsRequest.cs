using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Levels.Requests;

public class GetAllLevelsRequest : IRequest<ActionResponse>
{
}