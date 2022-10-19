using AutoMapper;
using Core.CQRS.Candidates.Requests;
using Core.CQRS.Candidates.Responses;
using Core.CQRS.Responses;
using Core.Entities.Candidates;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Candidates.Handlers;

public sealed class AddCandidateToRecruitmentRequestHandler
  : IRequestHandler<AddCandidateToRecruitmentRequest, ActionResponse>
{
  private readonly IMapper _mapper;
  private readonly IAppDbContext _context;
  private Candidate? _candidate;

  public AddCandidateToRecruitmentRequestHandler(IAppDbContext context,
    IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(AddCandidateToRecruitmentRequest request, CancellationToken cancellationToken)
  {
    var recruitment = await _context.Recruitments.FindAsync(request.RecruitmentId);

    if (recruitment == null)
      throw new NullReferenceException();

    bool isNullId = request.Id == 0;

    if (!isNullId)
      _candidate = await _context.Candidates.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

    bool existCandidate = !isNullId && _candidate != null;

    if (existCandidate)
    {
      var source = Candidate.Create(request);
      _candidate!.Update(source);
    } else
      _candidate = Candidate.Create(request);

    recruitment.CreateNewApplication(_candidate, request.Attachment);

    _context.Recruitments.Update(recruitment);

    await _context.Commit();

    var response = _mapper.Map<CandidateDetailResponse>(_candidate);

    return new SuccessResponse("Thêm ứng viên thành công", response);
  }
}