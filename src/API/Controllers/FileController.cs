using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/files")]
public class FileController : ControllerBase
{
  private readonly IFileUpload _uploader;

	public FileController(IFileUpload uploader)
	{
		_uploader = uploader;
	}

	[HttpPost]
	public async Task<IActionResult> Upload([FromForm] IFormFileCollection files)
	{
		var response = await _uploader.Upload(files[0]);
		return Ok(new { url = response });
	}
}