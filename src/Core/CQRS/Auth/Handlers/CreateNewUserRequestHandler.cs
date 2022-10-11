using Core.CQRS.Auth.Requests;
using Core.CQRS.Responses;
using Core.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.Handlers;

public sealed class CreateNewUserRequestHandler : IRequestHandler<CreateNewUserRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly RoleManager<IdentityRole> _roleManager;

  public CreateNewUserRequestHandler(UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager)
  {
    _userManager = userManager;
    _roleManager = roleManager;
  }

  public async Task<ActionResponse> Handle(CreateNewUserRequest request, CancellationToken cancellationToken)
  {
    var role = await _roleManager.FindByIdAsync(request.Role);

    if (role == null)
      return new NotFoundResponse();

    var user = await _userManager.FindByEmailAsync(request.Email)
      ?? await _userManager.FindByNameAsync(request.Username);

    if (user != null)
      return new NotFoundResponse();

    user = User.Create(request.Username, request.Email, request.Name, role.Name);

    var result = await _userManager.CreateAsync(user, request.Password);

    if (!result.Succeeded)
      return new NotFoundResponse();

    await _userManager.AddToRoleAsync(user, role.Name);

    return new SuccessResponse("Tạo user thành công", null);
  }
}