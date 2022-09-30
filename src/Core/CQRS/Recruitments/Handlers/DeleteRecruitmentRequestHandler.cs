using Core.CQRS.Recruitments.Requests;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Recruitments.Handlers;

public class DeleteRecruitmentRequestHandler : IRequestHandler<DeleteRecruitmentRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public DeleteRecruitmentRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(DeleteRecruitmentRequest request, CancellationToken cancellationToken)
  {
    var recruitment = await _context.Recruitments.FindAsync(request.Id);

    if (recruitment == null)
      return new NotFoundResponse();

    recruitment.Status = SharedKernel.Enums.Status.Inactive;

    _context.Recruitments.Update(recruitment);
    await _context.Commit();

    return new SuccessResponse("Xoá thành công", default);
  }
}