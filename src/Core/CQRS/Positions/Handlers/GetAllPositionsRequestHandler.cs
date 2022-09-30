using Core.CQRS.Positions.Requests;
using Core.CQRS.Positions.Responses;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Positions.Handlers;

public class GetAllPositionsRequestHandler : IRequestHandler<GetAllPositionsRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetAllPositionsRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public Task<ActionResponse> Handle(GetAllPositionsRequest request, CancellationToken cancellationToken)
  {
    var query = _context.Positions
      .Select(e => new ListPositionResponse
      {
        Id = e.Id,
        Name = e.Name
      }).AsNoTracking();

    var response = new SuccessResponse(null, query);

    return Task.FromResult<ActionResponse>(response);
  }
}