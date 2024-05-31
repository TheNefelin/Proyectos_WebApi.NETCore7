using BibliotecaAuth.Utils;
using BibliotecaGuiaJuegos.DTOs;
using BibliotecaGuiaJuegos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/GJ-Juego")]
    [ApiController]
    [Authorize(Roles = AuthPerfilUsuario.Admin)]
    public class GJJuegoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GJJuegoController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GJJuegoDTO_Get>>> GetAll(CancellationToken cancellationToken)
        {
            var entitys = await _context.GJJuegos.ToListAsync(cancellationToken);
            
            return entitys.Select(dto => new GJJuegoDTO_Get
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Img = dto.Img,
                Estado = dto.Estado
            }).ToList();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GJJuegoDTO_Get>> GetById(int Id)
        {
            var entity = await _context.GJJuegos.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            return new GJJuegoDTO_Get
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Descripcion = entity.Descripcion,
                Img = entity.Img,
                Estado = entity.Estado
            };
        }

        [HttpPost]
        public async Task<ActionResult<GJJuegoDTO_Get>> Insert(GJJuegoDTO_PostPut dto)
        {
            var mapEntity = new GJJuegoModel
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Img = dto.Img,
                Estado = dto.Estado
            };

            _context.GJJuegos.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new GJJuegoDTO_Get
            {
                Id = mapEntity.Id,
                Nombre = mapEntity.Nombre,
                Descripcion = mapEntity.Descripcion,
                Img = mapEntity.Img,
                Estado = mapEntity.Estado
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<GJJuegoDTO_Get>> Update(int Id, GJJuegoDTO_PostPut dto)
        {
            var mapEntity = new GJJuegoModel
            {
                Id = Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Img = dto.Img,
                Estado = dto.Estado
            };

            _context.Entry(mapEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = _context.GJJuegos.Any(e => e.Id == Id);
                if (!exist)
                    return NotFound(new { Msge = $"NotFound Id = {Id}" });
                else
                    throw;
            }

            var mapDto = new GJJuegoDTO_Get
            {
                Id = mapEntity.Id,
                Nombre = mapEntity.Nombre,
                Descripcion = mapEntity.Descripcion,
                Img = mapEntity.Img,
                Estado = mapEntity.Estado
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var entity = await _context.GJJuegos.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            var existPersonaje = _context.GJPersonajes.Any(c => c.Id_Juego == entity.Id);
            if (existPersonaje)
                return BadRequest(new { Msge = $"BadRequest Existe Referencia con GJPersonajes" });

            var existFuente = _context.GJFuentes.Any(c => c.Id_Juego == entity.Id);
            if (existFuente)
                return BadRequest(new { Msge = $"BadRequest Existe Referencia con GJFuentes" });

            var existFondoImg = _context.GJFondosImg.Any(c => c.Id_Juego == entity.Id);
            if (existFondoImg)
                return BadRequest(new { Msge = $"BadRequest Existe Referencia con GJFondosImg" });

            var existGuia = _context.GJGuias.Any(c => c.Id_Juego == entity.Id);
            if (existGuia)
                return BadRequest(new { Msge = $"BadRequest Existe Referencia con GJGuias" });

            _context.GJJuegos.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
