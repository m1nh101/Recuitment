using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public sealed record GetRecruitmentDetailRequest (
	int Id) : IRequest<ActionResponse>;