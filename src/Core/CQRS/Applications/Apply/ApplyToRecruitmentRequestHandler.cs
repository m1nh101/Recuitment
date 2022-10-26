using Core.CQRS.Responses;
using Core.Entities.Candidates;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Applications.Apply;

public sealed class ApplyToRecruitmentRequestHandler
  : IRequestHandler<ApplyToRecruitmentRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public ApplyToRecruitmentRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(ApplyToRecruitmentRequest request, CancellationToken cancellationToken)
  {
    Entities.Candidates.Candidate? candidate = null!;

    var recruitment = await _context.Recruitments.FirstOrDefaultAsync(e => e.Id == request.RecruitmentId);

    if (request.Id != 0)
      candidate = await _context.Candidates.FirstOrDefaultAsync(e => e.Id == request.Id);
    else
      candidate = Entities.Candidates.Candidate.Create(request.Name, request.Email, request.Phone, request.Birthday, 
        request.Address, request.Qualification, request.Gender, request.Note);

    if (candidate == null || recruitment == null)
      throw new NullReferenceException();

    recruitment.CreateNewApplication(candidate, request.Attachment ?? string.Empty); //tempory set empty value

    _context.Recruitments.Update(recruitment);

    await _context.Commit();

    return new SuccessResponse("Thêm thành công", request);
  }
}