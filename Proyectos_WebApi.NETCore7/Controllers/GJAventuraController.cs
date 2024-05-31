using BibliotecaGuiaJuegos.DTOs;
using BibliotecaGuiaJuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/GJ-Aventura")]
    [ApiController]
    public class GJAventuraController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GJAventuraController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GJAventuraDTO_Get>>> GetAll(CancellationToken cancellationToken)
        {
            var entitys = await _context.GJAventuras.ToListAsync(cancellationToken);

            return entitys.Select(dto => new GJAventuraDTO_Get
            {
                Id = dto.Id,
                Descripcion = dto.Descripcion,
                Importante = dto.Importante,
                Orden = dto.Orden,
                Id_Guia = dto.Id_Guia
            }).ToList();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GJAventuraDTO_Get>> GetById(int Id)
        {
            var entity = await _context.GJAventuras.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            return new GJAventuraDTO_Get
            {
                Id = entity.Id,
                Descripcion = entity.Descripcion,
                Importante = entity.Importante,
                Orden = entity.Orden,
                Id_Guia = entity.Id_Guia
            };
        }

        [HttpPost]
        public async Task<ActionResult<GJAventuraDTO_Get>> Insert(GJAventuraDTO_PostPut dto)
        {
            var mapEntity = new GJAventuraModel
            {
                Descripcion = dto.Descripcion,
                Importante = dto.Importante,
                Orden = dto.Orden,
                Id_Guia = dto.Id_Guia
            };

            var existGuia = _context.GJGuias.Any(c => c.Id == dto.Id_Guia);
            if (!existGuia)
                return NotFound(new { Msge = $"NotFound Id_Guia = {dto.Id_Guia}" });

            _context.GJAventuras.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new GJAventuraDTO_Get
            {
                Id = mapEntity.Id,
                Descripcion = mapEntity.Descripcion,
                Importante = mapEntity.Importante,
                Orden = mapEntity.Orden,
                Id_Guia = mapEntity.Id_Guia
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<GJAventuraDTO_Get>> Update(int Id, GJAventuraDTO_PostPut dto)
        {
            var mapEntity = new GJAventuraModel
            {
                Id = Id,
                Descripcion = dto.Descripcion,
                Importante = dto.Importante,
                Orden = dto.Orden,
                Id_Guia = dto.Id_Guia
            };

            var existGuia = _context.GJGuias.Any(c => c.Id == dto.Id_Guia);
            if (!existGuia)
                return NotFound(new { Msge = $"NotFound Id_Guia = {dto.Id_Guia}" });

            _context.Entry(mapEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = _context.GJAventuras.Any(e => e.Id == Id);
                if (!exist)
                    return NotFound(new { Msge = $"NotFound Id = {Id}" });
                else
                    throw;
            }

            var mapDto = new GJAventuraDTO_Get
            {
                Id = mapEntity.Id,
                Descripcion = mapEntity.Descripcion,
                Importante = mapEntity.Importante,
                Orden = mapEntity.Orden,
                Id_Guia = mapEntity.Id_Guia
            };

            return CreatedAtAction("GetById", new { Id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var entity = await _context.GJAventuras.FindAsync(Id);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id = {Id}" });

            _context.GJAventuras.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
