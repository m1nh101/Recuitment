using AutoMapper;
using Core.CQRS.Candidates.Requests;
using Core.CQRS.Candidates.Responses;
using Core.CQRS.Responses;
using Core.Entities.Candidates;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Candidates.Handlers;

public class AddCandidateToRecruitmentRequestHandler
  : IRequestHandler<AddCandidateToRecruitmentRequest, ActionResponse>
{
  private readonly IMapper _mapper;
  private readonly IAppDbContext _context;

  public AddCandidateToRecruitmentRequestHandler(IAppDbContext context,
    IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(AddCandidateToRecruitmentRequest request, CancellationToken cancellationToken)
  {
    var candidate = Candidate.Create(request);
    
    var recruitment = await _context.Recruitments.FindAsync(request.RecruitmentId);

    if (recruitment == null)
      throw new NullReferenceException();

    recruitment.CreateNewApplication(candidate, request.Attachment);

    _context.Recruitments.Update(recruitment);
    await _context.Commit();

    var response = _mapper.Map<CandidateDetailResponse>(candidate);

    return new SuccessResponse("Thêm ứng viên thành công", response);
  }
}
