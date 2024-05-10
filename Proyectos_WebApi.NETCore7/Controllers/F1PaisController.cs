using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;
using BibliotecaF1.DTOs;
using BibliotecaF1.Utils;
using Microsoft.AspNetCore.Authorization;
using BibliotecaAuth.Utils;

namespace Proyectos_WebApi.NETCore8.Controllers
{
    [Route("api/F1-Pais")]
    [ApiController]
    [Authorize(Roles = AuthPerfilUsuario.Admin)]
    public class F1PaisController : ControllerBase
    {
        private readonly ApiDbContext _context;
        
        public F1PaisController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<F1PaisGetDTO>>> GetAll()
        {
            var entitys = await _context.F1Paises.ToListAsync();
            if (entitys.Count == 0)
                return NotFound();

            return entitys.Select(new MapperF1().ToF1PaisDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<F1PaisGetDTO>> GetById(int id)
        {
            var entity = await _context.F1Paises.FindAsync(id);
            if (entity == null)
                return NotFound();

            return new MapperF1().ToF1PaisDto(entity);
        }

        [HttpPost]
        public async Task<ActionResult<F1PaisGetDTO>> Insert(F1PaisPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1PaisInsert(dto);

            _context.F1Paises.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new MapperF1().ToF1PaisDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<F1PaisGetDTO>> Update(int id, F1PaisPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1PaisUpdate(id, dto);
            _context.Entry(mapEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = _context.F1Paises.Any(e => e.Id == id);
                if (!exist)
                    return NotFound();
                else
                    throw;
            }

            var mapDto = new MapperF1().ToF1PaisDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.F1Paises.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.F1Paises.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
