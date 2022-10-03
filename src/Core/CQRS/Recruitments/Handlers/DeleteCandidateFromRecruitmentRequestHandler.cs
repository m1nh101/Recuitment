using Core.CQRS.Recruitments.Requests;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Recruitments.Handlers;

public class DeleteCandidateFromRecruitmentRequestHandler : IRequestHandler<DeleteCandidateFromRecruitmentRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public DeleteCandidateFromRecruitmentRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(DeleteCandidateFromRecruitmentRequest request, CancellationToken cancellationToken)
  {
    var recruitment = await _context.Recruitments
      .Include(e => e.Applications)
      .FirstOrDefaultAsync(e => e.Id == request.RecruitmentId, cancellationToken);

    if (recruitment == null)
      return new NotFoundResponse();

    recruitment.RemoveApplication(request.CandidateId);

    _context.Recruitments.Update(recruitment);
    await _context.Commit();

    return new SuccessResponse("Xoá thành công", null);
  }
}