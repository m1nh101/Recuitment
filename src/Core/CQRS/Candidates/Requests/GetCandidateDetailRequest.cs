using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Candidates.Requests;

public sealed record GetCandidateDetailRequest(
	int Id,
	int RecruitmentId) : IRequest<ActionResponse>;