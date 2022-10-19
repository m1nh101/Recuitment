using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public sealed record GetAllRecruitmentsRequest : IRequest<ActionResponse>;