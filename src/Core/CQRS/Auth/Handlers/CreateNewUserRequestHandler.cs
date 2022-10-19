using AutoMapper;
using Core.CQRS.Auth.Requests;
using Core.CQRS.Auth.Responses;
using Core.CQRS.Responses;
using Core.Entities.Users;
using Core.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.Handlers;

public sealed class CreateNewUserRequestHandler : IRequestHandler<CreateNewUserRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;
  private readonly RoleManager<IdentityRole> _roleManager;
  private readonly IMapper _mapper;
  private readonly Random _random;

  public CreateNewUserRequestHandler(UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IMapper mapper)
  {
    _userManager = userManager;
    _roleManager = roleManager;
    _mapper = mapper;
    _random = new Random();
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

    user.DepartmentId = request.DepartmentId;
    user.LevelId = request.LevelId;
    user.PositionId = request.PositionId;

    var password = _random.Password();

    var result = await _userManager.CreateAsync(user, password);

    if (!result.Succeeded)
      return new NotFoundResponse();

    await _userManager.AddToRoleAsync(user, role.Name);

    var response = _mapper.Map<AddedEmployeeResponse>(user);
    response.Role = response.Role;

    return new SuccessResponse("Tạo user thành công", response);
  }
}