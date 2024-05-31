using BibliotecaAuth.Utils;
using BibliotecaGuiaJuegos.DTOs;
using BibliotecaGuiaJuegos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/GJ-Guia")]
    [ApiController]
    [Authorize(Roles = AuthPerfilUsuario.Admin)]
    public class GJGuiaController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GJGuiaController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GJGuiaDTO_Get>>> GetAll(CancellationToken cancellationToken)
        {
            var entitys = await _context.GJGuias.ToListAsync(cancellationToken);

            return entitys.Select(dto => new GJGuiaDTO_Get
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Orden = dto.Orden,
                Id_Juego = dto.Id_Juego
            }).ToList();
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<GJGuiaDTO_Get>> GetById(int Id)
        {
            var entity = await _context.GJGuias.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            return new GJGuiaDTO_Get
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Orden = entity.Orden,
                Id_Juego = entity.Id_Juego
            };
        }

        [HttpPost]
        public async Task<ActionResult<GJGuiaDTO_Get>> Insert(GJGuiaDTO_PostPut dto)
        {
            var mapEntity = new GJGuiaModel
            {
                Nombre = dto.Nombre,
                Orden = dto.Orden,
                Id_Juego = dto.Id_Juego
            };

            var existJuego = _context.GJJuegos.Any(c => c.Id == dto.Id_Juego);
            if (!existJuego)
                return NotFound(new { Msge = $"NotFound Id_Juego = {dto.Id_Juego}" });

            _context.GJGuias.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new GJGuiaDTO_Get
            {
                Id = mapEntity.Id,
                Nombre = mapEntity.Nombre,
                Orden = mapEntity.Orden,
                Id_Juego = mapEntity.Id_Juego
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<GJGuiaDTO_Get>> Update(int Id, GJGuiaDTO_PostPut dto)
        {
            var mapEntity = new GJGuiaModel
            {
                Id = Id,
                Nombre = dto.Nombre,
                Orden = dto.Orden,
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
                var exist = _context.GJGuias.Any(e => e.Id == Id);
                if (!exist)
                    return NotFound(new { Msge = $"NotFound Id = {Id}" });
                else
                    throw;
            }

            var mapDto = new GJGuiaDTO_Get
            {
                Id = mapEntity.Id,
                Nombre = mapEntity.Nombre,
                Orden = mapEntity.Orden,
                Id_Juego = mapEntity.Id_Juego
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var entity = await _context.GJGuias.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            _context.GJGuias.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

