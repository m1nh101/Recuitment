using Core.CQRS.Auth.Requests;
using Core.CQRS.Responses;
using Core.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.Handlers;

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
    var user = await _userManager.FindByEmailAsync(request.Email);

    if(user == null)
      return new NotFoundResponse();

    var validCredential = await _userManager.CheckPasswordAsync(user, request.Password);

    if(!validCredential)
      return new BadRequestResponse(new {}, "Sai email hoặc mật khẩu");

    return new SuccessResponse(string.Empty, user);
  }
}
