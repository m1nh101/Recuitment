using AutoMapper;
using Core.CQRS.Candidates.Requests;
using Core.CQRS.Candidates.Responses;
using Core.CQRS.Responses;
using Core.Entities.Candidates;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Candidates.Handlers;

public class UpdateCandidateRequestHandler : IRequestHandler<UpdateCandidateRequest, ActionResponse>
{
  private readonly IMapper _mapper;
  private readonly IAppDbContext _context;

  public UpdateCandidateRequestHandler(IMapper mapper, IAppDbContext context)
  {
    _mapper = mapper;
    _context = context;
  }

  public async Task<ActionResponse> Handle(UpdateCandidateRequest request, CancellationToken cancellationToken)
  {
    var candidate = await _context.Candidates
      .Include(e => e.Applications)
      .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

    if (candidate == null)
      return new NotFoundResponse();

    var payload = _mapper.Map<Candidate>(request.Payload);
    
    if (request.Payload.RecruitmentId != 0)
      candidate.Update(payload, request.Payload.RecruitmentId, request.Payload.Attachment);
    else
      candidate.Update(payload);

    _context.Candidates.Update(candidate);
    await _context.Commit();

    var response = _mapper.Map<CandidateDetailResponse>(candidate);

    return new SuccessResponse("Cập nhật thông tin thành công", response);
  }
}