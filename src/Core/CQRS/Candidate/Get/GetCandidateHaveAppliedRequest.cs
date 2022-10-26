using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Candidate.Get;

public sealed record GetAllCandidateHaveAppliedRequest : IRequest<ActionResponse>;