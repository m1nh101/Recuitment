using Core.CQRS.Departments.Requests;
using Core.CQRS.Departments.Responses;
using Core.CQRS.Responses;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Departments.Handlers;

public class GetAllDepartmentsRequestHandler : IRequestHandler<GetAllDepartmentsRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetAllDepartmentsRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public Task<ActionResponse> Handle(GetAllDepartmentsRequest request, CancellationToken cancellationToken)
  {
    var query = _context.Departments
      .Select(e => new GeneralDepartmentResponse
      {
        Id = e.Id,
        Name = e.Name,
        Location = e.Location
      })
      .AsNoTracking();

    var response = new SuccessResponse(null, query);

    return Task.FromResult<ActionResponse>(response);
  }
}