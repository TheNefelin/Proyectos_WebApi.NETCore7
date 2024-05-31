using BibliotecaGuiaJuegos.DTOs;
using BibliotecaGuiaJuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GJAventuraImgController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GJAventuraImgController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GJAventuraImgDTO_Get>>> GetAll(CancellationToken cancellationToken)
        {
            var entitys = await _context.GJAventurasImg.ToListAsync(cancellationToken);

            return entitys.Select(dto => new GJAventuraImgDTO_Get
            {
                Id = dto.Id,
                Img = dto.Img,
                Orden = dto.Orden,
                Id_Aventura = dto.Id_Aventura,
            }).ToList();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GJAventuraImgDTO_Get>> GetById(int Id)
        {
            var entity = await _context.GJAventurasImg.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            return new GJAventuraImgDTO_Get
            {
                Id = entity.Id,
                Img = entity.Img,
                Orden = entity.Orden,
                Id_Aventura = entity.Id_Aventura
            };
        }

        [HttpPost]
        public async Task<ActionResult<GJAventuraImgDTO_Get>> Insert(GJAventuraImgDTO_PostPut dto)
        {
            var mapEntity = new GJAventuraImgModel
            {
                Img = dto.Img,
                Orden = dto.Orden,
                Id_Aventura = dto.Id_Aventura
            };

            var existAventura = _context.GJAventuras.Any(c => c.Id == dto.Id_Aventura);
            if (!existAventura)
                return NotFound(new { Msge = $"NotFound Id_Aventura = {dto.Id_Aventura}" });

            _context.GJAventurasImg.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new GJAventuraImgDTO_Get
            {
                Id = mapEntity.Id,
                Img = mapEntity.Img,
                Orden = mapEntity.Orden,
                Id_Aventura = mapEntity.Id_Aventura
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<GJAventuraImgDTO_Get>> Update(int Id, GJAventuraImgDTO_PostPut dto)
        {
            var mapEntity = new GJAventuraImgModel
            {
                Id = Id,
                Img = dto.Img,
                Orden = dto.Orden,
                Id_Aventura = dto.Id_Aventura
            };

            var existAventura = _context.GJAventuras.Any(c => c.Id == dto.Id_Aventura);
            if (!existAventura)
                return NotFound(new { Msge = $"NotFound Id_Aventura = {dto.Id_Aventura}" });

            _context.Entry(mapEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = _context.GJAventurasImg.Any(e => e.Id == Id);
                if (!exist)
                    return NotFound(new { Msge = $"NotFound Id = {Id}" });
                else
                    throw;
            }

            var mapDto = new GJAventuraImgDTO_Get
            {
                Id = mapEntity.Id,
                Img = mapEntity.Img,
                Orden = mapEntity.Orden,
                Id_Aventura = mapEntity.Id_Aventura
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var entity = await _context.GJAventurasImg.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            _context.GJAventurasImg.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
