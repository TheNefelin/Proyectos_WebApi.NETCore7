using BibliotecaAuth.Utils;
using BibliotecaGuiaJuegos.DTOs;
using BibliotecaGuiaJuegos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore7.Controllers
{
    [Route("api/GJ-AventuraUsuario")]
    [ApiController]
    [Authorize(Roles = AuthPerfilUsuario.Admin)]
    public class GJAventuraUsuarioController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public GJAventuraUsuarioController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GJAventuraUsuarioDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var entitys = await _context.GJAventurasUsuario.ToListAsync(cancellationToken);

            return entitys.Select(dto => new GJAventuraUsuarioDTO
            {
                Id_Aventura = dto.Id_Aventura,
                Id_Usuario = dto.Id_Usuario,
                Estado = dto.Estado
            }).ToList();
        }

        [HttpGet("{Id_Aventura},{Id_Usuario}")]
        public async Task<ActionResult<GJAventuraUsuarioDTO>> GetById(int Id_Aventura, string Id_Usuario)
        {
            var entity = await _context.GJAventurasUsuario.FirstOrDefaultAsync(e => e.Id_Aventura == Id_Aventura && e.Id_Usuario == Id_Usuario);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id_Aventura = {Id_Aventura} and Id_Usuario = {Id_Usuario}" });

            return new GJAventuraUsuarioDTO
            {
                Id_Aventura = entity.Id_Aventura,
                Id_Usuario = entity.Id_Usuario,
                Estado = entity.Estado
            };
        }

        [HttpPost]
        public async Task<ActionResult<GJAventuraUsuarioDTO>> Insert(GJAventuraUsuarioDTO dto)
        {
            var mapEntity = new GJAventuraUsuarioModel
            {
                Id_Aventura = dto.Id_Aventura,
                Id_Usuario = dto.Id_Usuario,
                Estado = dto.Estado
            };

            var existUsuario = _context.AuthUsuario.Any(c => c.Id == dto.Id_Usuario);
            if (!existUsuario)
                return NotFound(new { Msge = $"NotFound Id_Usuario = {dto.Id_Usuario}" });

            var existAventura = _context.GJAventuras.Any(c => c.Id == dto.Id_Aventura);
            if (!existAventura)
                return NotFound(new { Msge = $"NotFound Id_Aventura = {dto.Id_Aventura}" });

            var existAventuraUsuario = _context.GJAventurasUsuario.Any(c => c.Id_Aventura == dto.Id_Aventura && c.Id_Usuario == c.Id_Usuario);
            if (existAventuraUsuario)
                return BadRequest(new { Msge = $"El Elemento ya existe" });

            _context.GJAventurasUsuario.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new GJAventuraUsuarioDTO
            {
                Id_Aventura = mapEntity.Id_Aventura,
                Id_Usuario = mapEntity.Id_Usuario,
                Estado = mapEntity.Estado
            };

            return CreatedAtAction("GetById", new { Id_Aventura = mapDto.Id_Aventura, Id_Usuario = mapDto.Id_Usuario }, mapDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(GJAventuraUsuarioDTO dto)
        {
            var entity = await _context.GJAventurasUsuario.FirstOrDefaultAsync(e => e.Id_Aventura == dto.Id_Aventura && e.Id_Usuario == dto.Id_Usuario);
            if (entity == null)
                return NotFound(new { Msge = $"NotFound Id_Aventura = {dto.Id_Aventura} and Id_Usuario = {dto.Id_Usuario}" });

            _context.GJAventurasUsuario.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
