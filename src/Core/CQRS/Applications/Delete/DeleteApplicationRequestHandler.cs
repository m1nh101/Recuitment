using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Applications.Delete;

public sealed class DeleteApplicationRequestHandler
  : IRequestHandler<DeleteApplicationRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public DeleteApplicationRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(DeleteApplicationRequest request, CancellationToken cancellationToken)
  {
    var recruitment = _context.Recruitments.Any(e => e.Id == request.RecruitmentId);

    if (!recruitment)
      throw new NullReferenceException();

    var application = await _context.Applications.FirstOrDefaultAsync(e => e.Id == request.ApplicationId, cancellationToken);

    if (application == null)
      throw new NullReferenceException();

    application.UpdateStatus(SharedKernel.Enums.Status.None);

    _context.Applications.Update(application);

    await _context.Commit();

    return new SuccessResponse("Xoá thành công", null);
  }
}