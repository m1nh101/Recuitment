using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Enums;

namespace Core.CQRS.Interviews;

public sealed record StartedInterviewResponse(
  DateTime Time
)
{
  public Status Status { get; } = Status.OnProcessing;
}

public sealed class StartInterviewRequestHandler
  : IRequestHandler<StartInterviewRequest, ActionResponse>
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

    var time = application.Booking!.Interview!.Start();

    _context.Applications.Update(application);

    await _context.Commit();

    var response = new StartedInterviewResponse(time);

    return new SuccessResponse("Ok", response);
  }
}
