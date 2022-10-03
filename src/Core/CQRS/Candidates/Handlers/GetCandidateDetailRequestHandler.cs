using AutoMapper;
using Core.CQRS.Candidates.Requests;
using Core.CQRS.Candidates.Responses;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Candidates.Handlers;

public class GetCandidateDetailRequestHandler : IRequestHandler<GetCandidateDetailRequest, ActionResponse>
{
  private readonly IMapper _mapper;
  private readonly IAppDbContext _context;

  public GetCandidateDetailRequestHandler(IMapper mapper,
    IAppDbContext context)
  {
    _mapper = mapper;
    _context = context;
  }

  public async Task<ActionResponse> Handle(GetCandidateDetailRequest request, CancellationToken cancellationToken)
  {
    var candidate = await _context.Candidates.Include(e => e.Applications)
      .FirstOrDefaultAsync(e => e.Id == request.Id);

    if (candidate == null)
      return new NotFoundResponse();

    var response = _mapper.Map<CandidateDetailResponse>(candidate);
    response.Attachment = candidate.GetAttachmentByRecruitment(request.RecruitmentId);

    return new SuccessResponse(null, response);
  }
}