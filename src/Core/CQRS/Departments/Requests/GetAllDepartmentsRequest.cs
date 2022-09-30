using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Departments.Requests;

public class GetAllDepartmentsRequest : IRequest<ActionResponse>
{
}