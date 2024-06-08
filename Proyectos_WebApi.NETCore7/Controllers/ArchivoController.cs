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
        [Route("GuiaJuegos")]
        public IActionResult GetGuiaJuegosFile(string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\GuiaJuegos\\";
            var filePath = Path.Combine(path, fileName);

            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);

                return File(b, "image/webp");
            }

            return BadRequest(new { Msge = "No Existe el Archivo" });
        }

        [HttpGet]
        [Route("F1")]
        public IActionResult GetF1File(string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\F1\\";
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
