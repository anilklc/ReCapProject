using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        public UploadImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult AddImage([FromForm] FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\Uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + fileUpload.file.FileName))
                    {
                        fileUpload.file.CopyTo(fileStream);
                        fileStream.Flush();
                        return Ok();
                    }
                }
                else 
                {
                    return BadRequest(); 
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet("{fileName}")]
        public IActionResult GetImage([FromRoute] string fileName) 
        {
            string path = _webHostEnvironment.WebRootPath + "\\Uploads\\";
            var filePath = path + fileName + ".png";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b=System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");
            }
            return null;
        }
    }
}
