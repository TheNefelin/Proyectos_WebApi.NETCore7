using BibliotecaAuth.Utils;
using BibliotecaF1.DTOs;
using BibliotecaF1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore8.Controllers
{
    [Route("api/F1-Circuito")]
    [ApiController]
    [Authorize(Roles = AuthPerfilUsuario.Admin)]
    public class F1CircuitoController : ControllerBase
    {
        public readonly ApiDbContext _context;

        public F1CircuitoController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<F1CircuitoGetDTO>>> GetAll()
        {
            var entitys = await _context.F1Circuitos.ToListAsync();

            return entitys.Select(new MapperF1().ToF1CircuitoDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<F1CircuitoGetDTO>> GetById(int id)
        {
            var entity = await _context.F1Circuitos.FindAsync(id);
            if (entity == null)
                return NotFound();

            return new MapperF1().ToF1CircuitoDto(entity);
        }

        [HttpPost]
        public async Task<ActionResult<F1CircuitoGetDTO>> Insert(F1CircuitoPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1CircuitoInsert(dto);

            _context.F1Circuitos.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new MapperF1().ToF1CircuitoDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<F1CircuitoGetDTO>> Update(int id, F1CircuitoPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1CircuitoUpdate(id, dto);
            _context.Entry(mapEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = _context.F1Circuitos.Any(e => e.Id == id);
                if (!exist)
                    return NotFound();
                else
                    throw;
            }

            var mapDto = new MapperF1().ToF1CircuitoDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.F1Circuitos.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.F1Circuitos.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
