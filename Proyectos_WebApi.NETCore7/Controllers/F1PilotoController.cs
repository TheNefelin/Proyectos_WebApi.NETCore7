using BibliotecaAuth.Utils;
using BibliotecaF1.DTOs;
using BibliotecaF1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore8.Controllers
{
    [Route("api/F1-Piloto")]
    [ApiController]
    [Authorize(Roles = AuthPerfilUsuario.Admin)]
    public class F1PilotoController : ControllerBase
    {
        public readonly ApiDbContext _context;
        
        public F1PilotoController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<F1PilotoGetDTO>>> GetAll()
        {
            var entitys = await _context.F1Pilotos.ToListAsync();

            return entitys.Select(new MapperF1().ToF1PilotoDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<F1PilotoGetDTO>> GetById(int id)
        {
            var entity = await _context.F1Pilotos.FindAsync(id);
            if (entity == null)
                return NotFound();

            return new MapperF1().ToF1PilotoDto(entity);
        }

        [HttpPost]
        public async Task<ActionResult<F1PilotoGetDTO>> Insert(F1PilotoPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1PilotoInsert(dto);

            var existEscuderia = _context.F1Escuderias.Any(c => c.Id == dto.IdEscuderia);
            if (!existEscuderia)
                return NotFound();

            _context.F1Pilotos.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new MapperF1().ToF1PilotoDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<F1PilotoGetDTO>> Update(int id, F1PilotoPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1PilotoUpdate(id, dto);

            var existEscuderia = _context.F1Escuderias.Any(c => c.Id == dto.IdEscuderia);
            if (!existEscuderia)
                return NotFound();

            _context.Entry(mapEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = _context.F1Pilotos.Any(e => e.Id == id);
                if (!exist)
                    return NotFound();
                else
                    throw;
            }

            var mapDto = new MapperF1().ToF1PilotoDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.F1Pilotos.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.F1Pilotos.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
