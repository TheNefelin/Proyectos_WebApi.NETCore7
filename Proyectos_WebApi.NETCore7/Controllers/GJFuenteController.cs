using BibliotecaGuiaJuegos.DTOs;
using BibliotecaGuiaJuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/GJ-Fuente")]
    [ApiController]
    public class GJFuenteController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GJFuenteController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GJFuenteDTO_Get>>> GetAll(CancellationToken cancellationToken)
        {
            var entitys = await _context.GJFuentes.ToListAsync(cancellationToken);

            return entitys.Select(dto => new GJFuenteDTO_Get
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Img = dto.Img,
                Id_Juego = dto.Id_Juego
            }).ToList();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GJFuenteDTO_Get>> GetById(int Id)
        {
            var entity = await _context.GJFuentes.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            return new GJFuenteDTO_Get
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Img = entity.Img,
                Id_Juego = entity.Id_Juego
            };
        }

        [HttpPost]
        public async Task<ActionResult<GJFuenteDTO_Get>> Insert(GJFuenteDTO_PostPut dto)
        {
            var mapEntity = new GJFuenteModel
            {
                Nombre = dto.Nombre,
                Img = dto.Img,
                Id_Juego = dto.Id_Juego
            };

            var existJuego = _context.GJJuegos.Any(c => c.Id == dto.Id_Juego);
            if (!existJuego)
                return NotFound(new { Msge = $"NotFound Id_Juego = {dto.Id_Juego}" });

            _context.GJFuentes.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new GJFuenteDTO_Get
            {
                Id = mapEntity.Id,
                Nombre = mapEntity.Nombre,
                Img = mapEntity.Img,
                Id_Juego = mapEntity.Id_Juego
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<GJFuenteDTO_Get>> Update(int Id, GJFuenteDTO_PostPut dto)
        {
            var mapEntity = new GJFuenteModel
            {
                Id = Id,
                Nombre = dto.Nombre,
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
                var exist = _context.GJFuentes.Any(e => e.Id == Id);
                if (!exist)
                    return NotFound(new { Msge = $"NotFound Id = {Id}" });
                else
                    throw;
            }

            var mapDto = new GJFuenteDTO_Get
            {
                Id = mapEntity.Id,
                Nombre = mapEntity.Nombre,
                Img = mapEntity.Img,
                Id_Juego = mapEntity.Id_Juego
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var entity = await _context.GJFuentes.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            _context.GJFuentes.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
