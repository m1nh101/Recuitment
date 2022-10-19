using Core.CQRS.Auth.Requests;
using Core.CQRS.Auth.Responses;
using Core.CQRS.Responses;
using Core.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Auth.Handlers;

public sealed class GetAllReviewerRequestHandler : IRequestHandler<GetAllReviewerRequest, ActionResponse>
{
  private readonly UserManager<User> _userManager;

  public GetAllReviewerRequestHandler(UserManager<User> userManager)
  {
    _userManager = userManager;
  }

  public Task<ActionResponse> Handle(GetAllReviewerRequest request, CancellationToken cancellationToken)
  {
    var query = _userManager.Users
      .Include(e => e.Department)
      .Select(e => new ListReviewerResponse
      {
        Id = e.Id,
        Name = e.Name,
        Department = e.Department!.Name
      });

    var response = new SuccessResponse("Thành công", query);

    return Task.FromResult<ActionResponse>(response);
  }
}