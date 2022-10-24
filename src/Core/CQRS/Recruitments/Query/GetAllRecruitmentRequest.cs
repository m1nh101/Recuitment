using Core.CQRS.Responses;
using Core.Entities.Recruitments;
using MediatR;

namespace Core.CQRS.Recruitments.Query;

public sealed record GetAllRecruitmentRequest : IRequest<ActionResponse>;