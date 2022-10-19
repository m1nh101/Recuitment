using AutoMapper;
using Core.CQRS.Interviews.Requests;
using Core.CQRS.Responses;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Interviews.Handlers;

public sealed class FinishInterviewRequestHandler : IRequestHandler<FinishInterviewRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public FinishInterviewRequestHandler(IAppDbContext context,
    IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(FinishInterviewRequest request, CancellationToken cancellationToken)
  {
    var application = await _context.Applications
      .Include(e => e.Booking!)
      .ThenInclude(e => e.Interview)
      .FirstOrDefaultAsync(e => e.Id == request.ApplicationId);

    if(application == null)
      throw new NullReferenceException();

    var interview = application.Booking!.Interview!;

    interview.Finish();
    
    if(request.Payload != null)
    {
      var payload = _mapper.Map<InterviewResult>(request.Payload);

      interview.EvaluateCandidate(payload);
    }

    _context.Applications.Update(application);

    await _context.Commit();

    return new SuccessResponse(null, null);
  }
}