using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : ControllerBase
    {
        private static IWebHostEnvironment _webHostEnvironment;

        public ArchivoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetFile(string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\img\\";
            var filePath = Path.Combine(path, fileName);

            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);

                return File(b, "image/webp");
            }

            return BadRequest(new { Msge = "No Existe el Archivo" });
        }
    }
}
