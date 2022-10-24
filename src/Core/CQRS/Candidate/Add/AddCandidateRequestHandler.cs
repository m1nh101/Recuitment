using AutoMapper;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Candidate.Add;

public sealed record AddCandidateRequestHandler
  : IRequestHandler<AddCandidateRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public AddCandidateRequestHandler(IAppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(AddCandidateRequest request, CancellationToken cancellationToken)
  {
    var recruitment = await _context.Recruitments
      .Include(e => e.Applications)
      .FirstOrDefaultAsync(e => e.Id == request.RecruitmentId);

    if(recruitment == null)
      throw new NullReferenceException();

    Core.Entities.Candidates.Candidate? candidate = new Entities.Candidates.Candidate();

    if(request.Id != 0)
    {
      candidate = await _context.Candidates.FindAsync(request.Id);

      if(candidate == null)
        throw new NullReferenceException();
    } else
       candidate = Core.Entities.Candidates.Candidate.Create(request.Name, request.Email, request.Phone,
        request.Birthday, request.Address, request.Qualification, request.Gender, "");

    var application = recruitment.CreateNewApplication(candidate, request.Attachment);

    _context.Recruitments.Update(recruitment);

    await _context.Commit();

    var response = _mapper.Map<AddedCandidateResponse>(request);

    return new SuccessResponse("Thêm ứng viên thành công", response);
  }
}
