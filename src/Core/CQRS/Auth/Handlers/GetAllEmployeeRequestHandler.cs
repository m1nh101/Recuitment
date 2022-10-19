using Core.CQRS.Auth.Requests;
using Core.CQRS.Auth.Responses;
using Core.CQRS.Responses;
using Core.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Auth.Handlers;

public sealed class GetAllEmployeeRequestHandler : IRequestHandler<GetAllEmployeeRequest, ActionResponse>
{
  private readonly UserManager<User> _userManger;
  private readonly RoleManager<IdentityRole> _roleManager;

  public GetAllEmployeeRequestHandler(UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager)
  {
    _userManger = userManager;
    _roleManager = roleManager;
  }

  public Task<ActionResponse> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
  {
    var query = _userManger.Users
      .Include(e => e.Level)
      .Include(e => e.Department)
      .Include(e => e.Position)
      .AsNoTracking()
      .Where(e => e.Id != "d1d99d84-f944-43c2-872a-8e66386ab936")
      .Select(e => new ListEmployeeResponse
      {
        Id = e.Id,
        Name = e.Name,
        Department = e.Department!.Name,
        Position = e.Position!.Name,
        Level = e.Level!.Name,
        Role = e.Role
      });

    var response = new SuccessResponse("Thành công", query);

    return Task.FromResult<ActionResponse>(response);
  }
}