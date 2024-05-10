using BibliotecaAuth.Utils;
using BibliotecaF1.DTOs;
using BibliotecaF1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore8.Controllers
{
    [Route("api/F1-Escuderia")]
    [ApiController]
    [Authorize(Roles = AuthPerfilUsuario.Admin)]
    public class F1EscuderiaController : ControllerBase
    {
        public readonly ApiDbContext _context;

        public F1EscuderiaController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<F1EscuderiaGetDTO>>> GetAll()
        {
            var entitys = await _context.F1Escuderias.ToListAsync();

            return entitys.Select(new MapperF1().ToF1EscuderiaDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<F1EscuderiaGetDTO>> GetById(int id)
        {
            var entity = await _context.F1Escuderias.FindAsync(id);
            if (entity == null)
                return NotFound();

            return new MapperF1().ToF1EscuderiaDto(entity);
        }

        [HttpPost]
        public async Task<ActionResult<F1EscuderiaGetDTO>> Insert(F1EscuderiaPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1EscuderiaInsert(dto);

            _context.F1Escuderias.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new MapperF1().ToF1EscuderiaDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<F1EscuderiaGetDTO>> Update(int id, F1EscuderiaPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1EscuderiaUpdate(id, dto);
            _context.Entry(mapEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = _context.F1Escuderias.Any(e => e.Id == id);
                if (!exist)
                    return NotFound();
                else
                    throw;
            }

            var mapDto = new MapperF1().ToF1EscuderiaDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.F1Escuderias.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.F1Escuderias.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
