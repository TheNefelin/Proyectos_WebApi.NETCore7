using BibliotecaGuiaJuegos.DTOs;
using BibliotecaGuiaJuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GJFondoImgController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GJFondoImgController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GJFondoImgDTO_Get>>> GetAll(CancellationToken cancellationToken)
        {
            var entitys = await _context.GJFondosImg.ToListAsync(cancellationToken);

            return entitys.Select(dto => new GJFondoImgDTO_Get
            {
                Id = dto.Id,
                Img = dto.Img,
                Id_Juego = dto.Id_Juego
            }).ToList();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GJFondoImgDTO_Get>> GetById(int Id)
        {
            var entity = await _context.GJFondosImg.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            return new GJFondoImgDTO_Get
            {
                Id = entity.Id,
                Img = entity.Img,
                Id_Juego = entity.Id_Juego
            };
        }

        [HttpPost]
        public async Task<ActionResult<GJFondoImgDTO_Get>> Insert(GJFondoImgDTO_PostPut dto)
        {
            var mapEntity = new GJFondoImgModel
            {
                Img = dto.Img,
                Id_Juego = dto.Id_Juego
            };

            var existJuego = _context.GJJuegos.Any(c => c.Id == dto.Id_Juego);
            if (!existJuego)
                return NotFound(new { Msge = $"NotFound Id_Juego = {dto.Id_Juego}" });

            _context.GJFondosImg.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new GJFondoImgDTO_Get
            {
                Id = mapEntity.Id,
                Img = mapEntity.Img,
                Id_Juego = mapEntity.Id_Juego
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<GJFondoImgDTO_Get>> Update(int Id, GJFondoImgDTO_PostPut dto)
        {
            var mapEntity = new GJFondoImgModel
            {
                Id = Id,
                Img = dto.Img,
                Id_Juego = dto.Id_Juego
            };

            var existJuego = _context.GJJuegos.Any(c => c.Id == dto.Id_Juego);
            if (!existJuego)
                return NotFound(new { Msge = $"NotFound Id_Juego = {dto.Id_Juego}" });

            _context.Entry(mapEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = _context.GJFondosImg.Any(e => e.Id == Id);
                if (!exist)
                    return NotFound(new { Msge = $"NotFound Id = {Id}" });
                else
                    throw;
            }

            var mapDto = new GJFondoImgDTO_Get
            {
                Id = mapEntity.Id,
                Img = mapEntity.Img,
                Id_Juego = mapEntity.Id_Juego
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var entity = await _context.GJFondosImg.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            _context.GJFondosImg.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
