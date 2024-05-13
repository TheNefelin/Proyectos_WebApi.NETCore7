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
        public async Task<ActionResult<IEnumerable<F1RepoEscuderiaDTO>>> GetAllEscuderia()
        {
            var paisesDto = await getPaises();

            var escuderias = await _context.F1Escuderias
                .Include(e => e.F1Piloto)
                .ToListAsync();

            var res = escuderias.Select(e => new F1RepoEscuderiaDTO
            {
                Id = e.Id,
                Nombre = e.Nombre,
                UrlAuto = e.UrlAuto,
                Pais = paisesDto.Find(pa => pa.Id == e.IdPais)!,
                Pilotos = e.F1Piloto.Select(p => new F1RepoEscuderiaPilotoDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    FechaNacimiento = p.FechaNaci,
                    Estatura = p.Estatura,
                    Peso = p.Peso,
                    Dorsal = p.Dorsal,
                    UrlPerfil = p.UrlPerfil,
                    EstaVivo = p.EstaVivo,
                    Puntos = p.Puntos,
                    Pais = paisesDto.Find(pa => pa.Id == p.IdPais)!,
                }).ToList(),
            }).ToList();

            return res;
        }

        [HttpGet]
        [Route("F1-Pilotos")]
        public async Task<ActionResult<IEnumerable<F1RepoPilotoDTO>>> GetAll()
        {
            var paisesDto = await getPaises();

            var pilotos = await _context.F1Pilotos
                .Include(e => e.F1Escuderia)
                .ToListAsync();

            var res = pilotos.Select(e => new F1RepoPilotoDTO
            {
                Id = e.Id,
                Nombre = e.Nombre,
                FechaNacimiento = e.FechaNaci,
                Estatura = e.Estatura,
                Peso = e.Peso,
                Dorsal = e.Dorsal,
                UrlPerfil = e.UrlPerfil,
                EstaVivo = e.EstaVivo,
                Puntos = e.Puntos,
                Pais = paisesDto.Find(pa => pa.Id == e.IdPais)!,
                Escuderia = new F1RepoPilotoEscuderiaDTO
                {
                    Id = e.F1Escuderia.Id,
                    Nombre = e.F1Escuderia.Nombre,
                    UrlAuto = e.F1Escuderia.UrlAuto,
                    Pais = paisesDto.Find(pa => pa.Id == e.F1Escuderia.IdPais)!,
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
