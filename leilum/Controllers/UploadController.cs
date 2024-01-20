using Microsoft.AspNetCore.Mvc;

namespace leilum.Controllers;

[DisableRequestSizeLimit]
public class UploadController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public UploadController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpPost("upload/{type}/{name}")]
    public IActionResult Single(IFormFile file, string type, string name)
    {
        try
        {
            UploadFile(file, type, name);
            return StatusCode(200);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    public async Task UploadFile(IFormFile file, string folder, string name)
    {
        if (file != null && file.Length >0 )
        {
            var uploadPath = _environment.WebRootPath + "/" + folder;
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fullPath = Path.Combine(uploadPath,name + Path.GetExtension(file.FileName));
            using (FileStream stream = new FileStream(fullPath,FileMode.Create,FileAccess.Write))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}