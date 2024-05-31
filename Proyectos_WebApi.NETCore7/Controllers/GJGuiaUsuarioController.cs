using BibliotecaGuiaJuegos.DTOs;
using BibliotecaGuiaJuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/GJ-GuiaUsuario")]
    [ApiController]
    public class GJGuiaUsuarioController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GJGuiaUsuarioController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GJGuiaUsuarioDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var entitys = await _context.GJGuiasUsuario.ToListAsync(cancellationToken);

            return entitys.Select(dto => new GJGuiaUsuarioDTO
            {
                Id_Guia = dto.Id_Guia,
                Id_Usuario = dto.Id_Usuario,
                Estado = dto.Estado
            }).ToList();
        }

        [HttpGet("{Id_Guia},{Id_Usuario}")]
        public async Task<ActionResult<GJGuiaUsuarioDTO>> GetById(int Id_Guia, string Id_Usuario)
        {
            var entity = await _context.GJGuiasUsuario.FirstOrDefaultAsync(e => e.Id_Guia == Id_Guia && e.Id_Usuario == Id_Usuario);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id_Guia = {Id_Guia} and Id_Usuario = {Id_Usuario}" });

            return new GJGuiaUsuarioDTO
            {
                Id_Guia = entity.Id_Guia,
                Id_Usuario = entity.Id_Usuario,
                Estado = entity.Estado
            };
        }

        [HttpPost]
        public async Task<ActionResult<GJGuiaUsuarioDTO>> Insert(GJGuiaUsuarioDTO dto)
        {
            var mapEntity = new GJGuiaUsuarioModel
            {
                Id_Guia = dto.Id_Guia,
                Id_Usuario = dto.Id_Usuario,
                Estado = dto.Estado
            };

            var existUsuario = _context.AuthUsuario.Any(c => c.Id == dto.Id_Usuario);
            if (!existUsuario)
                return NotFound(new { Msge = $"NotFound Id_Usuario = {dto.Id_Usuario}" });

            var existGuia = _context.GJGuias.Any(c => c.Id == dto.Id_Guia);
            if (!existGuia)
                return NotFound(new { Msge = $"NotFound Id_Guia = {dto.Id_Guia}" });

            var existGuiaUsuario = _context.GJGuiasUsuario.Any(c => c.Id_Guia == dto.Id_Guia && c.Id_Usuario == c.Id_Usuario);
            if (existGuiaUsuario)
                return BadRequest(new { Msge = $"El Elemento ya existe" });

            _context.GJGuiasUsuario.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new GJGuiaUsuarioDTO
            {
                Id_Guia = mapEntity.Id_Guia,
                Id_Usuario = mapEntity.Id_Usuario,
                Estado = mapEntity.Estado
            };

            return CreatedAtAction("GetById", new { Id_Guia = mapDto.Id_Guia, Id_Usuario = mapDto.Id_Usuario }, mapDto);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(GJGuiaUsuarioDTO dto)
        {
            var entity = await _context.GJGuiasUsuario.FirstOrDefaultAsync(e => e.Id_Guia == dto.Id_Guia && e.Id_Usuario == dto.Id_Usuario);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id_Guia = {dto.Id_Guia} and Id_Usuario = {dto.Id_Usuario}" });

            _context.GJGuiasUsuario.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
