using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Auth.Requests;

public class GetAllEmployeeRequest : IRequest<ActionResponse>
{
}