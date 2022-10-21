using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Applications.Review;

public sealed class ReviewApplicationRequestHandler
  : IRequestHandler<ReviewApplicationRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public ReviewApplicationRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(ReviewApplicationRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications.FirstOrDefaultAsync(e => e.Id == request.ApplicationId);

    if (application == null)
      return new NotFoundResponse();

    application.UpdateStatus(request.Status);

    _context.Applications.Update(application);

    await _context.Commit();

    return new SuccessResponse("", new { });
  }
}