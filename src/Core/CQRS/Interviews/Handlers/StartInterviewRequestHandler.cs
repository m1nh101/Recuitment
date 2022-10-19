using Core.CQRS.Interviews.Requests;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Interviews.Handlers;

public class StartInterviewRequestHandler : IRequestHandler<StartInterviewRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public StartInterviewRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(StartInterviewRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications
      .Include(e => e.Booking!)
      .ThenInclude(e => e.Interview!)
      .FirstOrDefaultAsync(e => e.Id == request.ApplicationId);

    if (application == null)
      return new NotFoundResponse();

    application.Booking!.Interview!.Start();

    _context.Applications.Update(application);

    await _context.Commit();

    return new SuccessResponse(null, null);
  }
}