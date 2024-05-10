using BibliotecaF1.DTOs;
using BibliotecaF1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore8.Controllers
{
    [Route("api/Publico")]
    [ApiController]
    public class F1PublicoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public F1PublicoController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("F1-Escuderia")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAllEscuderia()
        {
            var paises = await getPaises();

            var entity = await _context.F1Escuderias
                .Include(e => e.F1Piloto)
                .ToListAsync();

            var res = entity.Select(e => new 
            {
                e.Id,
                e.Nombre,
                e.UrlAuto,
                //e.IdPais,
                Pais = paises.Find(pa => pa.Id == e.IdPais),
                Pilotos = e.F1Piloto == null ? null : e.F1Piloto.Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.FechaNaci,
                    p.Estatura,
                    p.Peso,
                    p.Dorsal,
                    p.UrlPerfil,
                    p.EstaVivo,
                    p.Puntos,
                    //p.IdPais,
                    //p.IdEscuderia,
                    Pais = paises.Find(pa => pa.Id == p.IdPais),
                }).ToList(),
            }).ToList();

            return res;
        }

        [HttpGet]
        [Route("F1-Pilotos")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAll()
        {
            var paises = await getPaises();

            var entity = await _context.F1Pilotos
                .Include(e => e.F1Escuderia)
                .ToListAsync();

            var res = entity.Select(e => new
            {
                e.Id,
                e.Nombre,
                e.FechaNaci,
                e.Estatura,
                e.Peso,
                e.Dorsal,
                e.UrlPerfil,
                e.EstaVivo,
                e.Puntos,
                //e.IdPais,
                //e.IdEscuderia,
                Pais = paises.Find(pa => pa.Id == e.IdPais),
                Escuderia = e.F1Escuderia == null ? null : new
                {
                    e.F1Escuderia.Id,
                    e.F1Escuderia.Nombre,
                    e.F1Escuderia.UrlAuto,
                    //e.F1Escuderia.IdPais,
                    Pais = paises.Find(pa => pa.Id == e.F1Escuderia.IdPais),
                }
            }).ToList();

            return res;
        }

        private async Task<List<F1PaisGetDTO>> getPaises()
        {
            var paises = await _context.F1Paises.ToListAsync();
            return paises.Select(new MapperF1().ToF1PaisDto).ToList();
        }
    }
}
