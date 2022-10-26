using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Candidate.Get;

public sealed class GetAllCandidatehaveAppliedRequestHandler
  : IRequestHandler<GetAllCandidateHaveAppliedRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetAllCandidatehaveAppliedRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public Task<ActionResponse> Handle(GetAllCandidateHaveAppliedRequest request, CancellationToken cancellationToken)
  {
    var candidates = _context.Candidates
      .AsNoTracking()
      .Select(e => new CandidateResponse(e.Id, e.Name, e.Address, e.Qualification, e.Birthday, e.Gender));

    var response = new SuccessResponse("Thành công", candidates);

    return Task.FromResult<ActionResponse>(response);
  }
}
