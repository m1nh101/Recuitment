using Core.CQRS.Levels.Requests;
using Core.CQRS.Levels.Responses;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Levels.Handlers;

public class GetAllLevelsRequestHandler : IRequestHandler<GetAllLevelsRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetAllLevelsRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public Task<ActionResponse> Handle(GetAllLevelsRequest request, CancellationToken cancellationToken)
  {
    var query = _context.Levels.Select(e => new ListLevelResponse
    {
      Id = e.Id,
      Name = e.Name
    }).AsNoTracking();

    var response = new SuccessResponse("Thành công", query);

    return Task.FromResult<ActionResponse>(response);
  }
}