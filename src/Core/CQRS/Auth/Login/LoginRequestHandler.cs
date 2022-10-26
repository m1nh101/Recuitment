using Core.CQRS.Responses;
using Core.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.Login;

public sealed class LoginRequestHandler
  : IRequestHandler<LoginRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;

  public LoginRequestHandler(UserManager<User> userManager)
  {
    _userManager = userManager;
  }

  public async Task<ActionResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
  {
    var user = await _userManager.FindByEmailAsync(request.Email) ?? new User();

    var isValidCredential = await _userManager.CheckPasswordAsync(user, request.Password);

    if(!isValidCredential)
      return new BadRequestResponse(new Object{}, "Sai email hoặc mật khẩu");

    return new SuccessResponse("Đăng nhập thành công", user);
  }
}
