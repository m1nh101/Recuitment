using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Recruitments.Requests;

public sealed record DeleteRecruitmentRequest(
	int Id) : IRequest<ActionResponse>;