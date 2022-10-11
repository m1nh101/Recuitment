using Core.CQRS.Auth.Requests;
using Core.CQRS.Auth.Responses;
using Core.CQRS.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Auth.Handlers;

public sealed class GetAllRoleRequestHandler : IRequestHandler<GetAllRoleRequest, ActionResponse>
{
  private readonly RoleManager<IdentityRole> _roleManager;

  public GetAllRoleRequestHandler(RoleManager<IdentityRole> roleManager)
  {
    _roleManager = roleManager;
  }

  public Task<ActionResponse> Handle(GetAllRoleRequest request, CancellationToken cancellationToken)
  {
    var query = _roleManager.Roles
      .AsNoTracking()
      .Select(e => new ListRoleResponse
      {
        Id = e.Id,
        Name = e.Name
      });

    var response = new SuccessResponse(null, query);

    return Task.FromResult<ActionResponse>(response);
  }
}