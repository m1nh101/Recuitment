namespace API.Helpers;

public interface IFileUpload
{
  Task<string> Upload(IFormFile file);
}

public class FileUpload : IFileUpload
{
  private readonly IWebHostEnvironment _env;

  public FileUpload(IWebHostEnvironment env)
  {
    _env = env;
  }

  public Task<string> Upload(IFormFile file)
  {
    string folderPath = Path.Combine(_env.ContentRootPath, "wwwroot", "pdf");
    var folder = FolderExist(folderPath);

    if (!folder)
      CreateFolder(folderPath);

    var filePath = Path.Combine(folderPath, file.FileName);

    using var stream = File.Create(filePath);
    file.CopyTo(stream);

    return Task.FromResult($"~/wwwroot/pdf/{file.FileName}");
  }


  private static bool FolderExist(string path) => Directory.Exists(path);

  private static void CreateFolder(string path) => Directory.CreateDirectory(path);
}