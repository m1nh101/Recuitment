using Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/utils")]
public sealed class UtilController : ControllerBase
{
  private readonly Util _util;

  public UtilController(Util util)
  {
    _util = util;
  }

  [HttpGet]
  [Route("levels")]
  public async Task<IActionResult> GetListLevel()
  {
    var response = await _util.GetLevels();

    return Ok(response);
  }

  [HttpGet]
  [Route("departments")]
  public async Task<IActionResult> GetListDepartment()
  {
    var response = await _util.GetDepartments();

    return Ok(response);
  }

  [HttpGet]
  [Route("positions")]
  public async Task<IActionResult> GetListPosition()
  {
    var response = await _util.GetPositions();

    return Ok(response);
  }
}