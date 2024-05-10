using BibliotecaAuth.Utils;
using BibliotecaF1.DTOs;
using BibliotecaF1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore8.Controllers
{
    [Route("api/F1-Carrera")]
    [ApiController]
    [Authorize(Roles = AuthPerfilUsuario.Admin)]
    public class F1CarreraController : ControllerBase
    {
        public readonly ApiDbContext _context;

        public F1CarreraController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<F1CarreraGetDTO>>> GetAll()
        {
            var entitys = await _context.F1Carreras.ToListAsync();

            return entitys.Select(new MapperF1().ToF1CarreraDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<F1CarreraGetDTO>> GetById(int id)
        {
            var entity = await _context.F1Carreras.FindAsync(id);
            if (entity == null)
                return NotFound();

            return new MapperF1().ToF1CarreraDto(entity);
        }

        [HttpPost]
        public async Task<ActionResult<F1CarreraGetDTO>> Insert(F1CarreraPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1CarreraInsert(dto);

            var existCircuito = _context.F1Circuitos.Any(c => c.Id == dto.IdCircuito);
            if (!existCircuito)
                return NotFound();

            _context.F1Carreras.Add(mapEntity);
            await _context.SaveChangesAsync();

            var mapDto = new MapperF1().ToF1CarreraDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<F1CarreraGetDTO>> Update(int id, F1CarreraPostPutDTO dto)
        {
            var mapEntity = new MapperF1().ToF1CarreraUpdate(id, dto);

            var existCircuito = _context.F1Circuitos.Any(c => c.Id == dto.IdCircuito);
            if (!existCircuito)
                return NotFound();

            _context.Entry(mapEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = _context.F1Carreras.Any(e => e.Id == id);
                if (!exist)
                    return NotFound();
                else
                    throw;
            }

            var mapDto = new MapperF1().ToF1CarreraDto(mapEntity);

            return CreatedAtAction("GetById", new { id = mapDto.Id }, mapDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.F1Carreras.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.F1Carreras.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
