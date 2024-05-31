using BibliotecaGuiaJuegos.DTOs;
using BibliotecaGuiaJuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/GJ-Personaje")]
    [ApiController]
    public class GJPersonajeController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GJPersonajeController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GJPersonajeDTO_Get>>> GetAll(CancellationToken cancellationToken)
        {
            var entitys = await _context.GJPersonajes.ToListAsync(cancellationToken);

            return entitys.Select(dto => new GJPersonajeDTO_Get
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Img = dto.Img,
                Id_Juego = dto.Id_Juego
            }).ToList();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GJPersonajeDTO_Get>> GetById(int Id)
        {
            var entity = await _context.GJPersonajes.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}"});

            return new GJPersonajeDTO_Get
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Descripcion = entity.Descripcion,
                Img = entity.Img,
                Id_Juego = entity.Id_Juego
            };
        }

        [HttpPost]
        public async Task<ActionResult<GJPersonajeDTO_Get>> Insert(GJPersonajeDTO_PostPut dto)
        {
            var mapEntity = new GJPersonajeModel
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Img = dto.Img,
                Id_Juego = dto.Id_Juego
            };

            var existJuego = _context.GJJuegos.Any(c => c.Id == dto.Id_Juego);
            if (!existJuego)
                return NotFound(new { Msge = $"NotFound Id_Juego = {dto.Id_Juego}" });

            _context.GJPersonajes.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new GJPersonajeDTO_Get
            {
                Id = mapEntity.Id,
                Nombre = mapEntity.Nombre,
                Descripcion = mapEntity.Descripcion,
                Img = mapEntity.Img,
                Id_Juego = mapEntity.Id_Juego
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<GJPersonajeDTO_Get>> Update(int Id, GJPersonajeDTO_PostPut dto)
        {
            var mapEntity = new GJPersonajeModel
            {
                Id = Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
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
                var exist = _context.GJPersonajes.Any(e => e.Id == Id);
                if (!exist)
                    return NotFound(new { Msge = $"NotFound Id = {Id}" });
                else
                    throw;
            }

            var mapDto = new GJPersonajeDTO_Get
            {
                Id = mapEntity.Id,
                Nombre = mapEntity.Nombre,
                Descripcion = mapEntity.Descripcion,
                Img = mapEntity.Img,
                Id_Juego = mapEntity.Id_Juego
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var entity = await _context.GJPersonajes.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            _context.GJPersonajes.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
