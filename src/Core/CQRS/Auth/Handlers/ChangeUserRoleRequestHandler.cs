using Core.CQRS.Auth.Requests;
using Core.CQRS.Responses;
using Core.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.Handlers;

public class ChangeUserRoleRequestHandler : IRequestHandler<ChangeUserRoleRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly RoleManager<IdentityRole> _roleManager;

  public ChangeUserRoleRequestHandler(UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager)
  {
    _userManager = userManager;
    _roleManager = roleManager;
  }

  public async Task<ActionResponse> Handle(ChangeUserRoleRequest request, CancellationToken cancellationToken)
  {
    var role = await _roleManager.FindByIdAsync(request.RoleId);
    var user = await _userManager.FindByIdAsync(request.UserId);

    if (user == null || role == null)
      return new NotFoundResponse();

    await _userManager.AddToRoleAsync(user, role.Name);

    return new SuccessResponse("Cập nhật role thành công", null);
  }
}