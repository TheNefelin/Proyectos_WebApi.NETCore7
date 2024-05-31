using BibliotecaF1.DTOs;
using BibliotecaF1.Utils;
using BibliotecaGuiaJuegos.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Proyectos_WebApi.NETCore8.Connection;

namespace Proyectos_WebApi.NETCore8.Controllers
{
    [Route("api/Publico")]
    [ApiController]
    public class PublicoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PublicoController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("F1-Escuderias")]
        public async Task<ActionResult<IEnumerable<F1RepoEscuderiaDTO>>> GetAllEscuderias()
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
        public async Task<ActionResult<IEnumerable<F1RepoPilotoDTO>>> GetAllPilotos()
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

        [HttpGet]
        [Route("GJ-Juego")]
        public async Task<ActionResult<IEnumerable<GJRepoJuegoDTO>>> GetAllJuegosV2()
        {
            var juegos = await _context.GJJuegos.ToListAsync();
            var personajes = await _context.GJPersonajes.ToListAsync();
            var fuentes = await _context.GJFuentes.ToListAsync();
            var fondoImg = await _context.GJFondosImg.ToListAsync();
            var guias = await _context.GJGuias.ToListAsync();
            var guiasUsuario = await _context.GJGuiasUsuario.ToListAsync();
            var aventuras = await _context.GJAventuras.ToListAsync();
            var aventurasUsuario = await _context.GJAventurasUsuario.ToListAsync();
            var aventurasImg = await _context.GJAventurasImg.ToListAsync();

            var dto = juegos.Select(juego => new GJRepoJuegoDTO
            {
                Id = juego.Id,
                Nombre = juego.Nombre,
                Descripcion = juego.Descripcion,
                Img = juego.Img,
                Estado = juego.Estado,
                Personajes = personajes.Where(e => e.Id_Juego == juego.Id).Select(personaje => new GJPersonajeDTO_Get
                {
                    Id = personaje.Id,
                    Nombre = personaje.Nombre,
                    Descripcion = personaje.Descripcion,
                    Img = personaje.Img,
                    Id_Juego = personaje.Id_Juego,
                }).ToList(),
                Fuentes = fuentes.Where(e => e.Id_Juego == juego.Id).Select(fuente => new GJFuenteDTO_Get
                {
                    Id = fuente.Id,
                    Nombre = fuente.Nombre,
                    Img = fuente.Img,
                    Id_Juego = fuente.Id_Juego,
                }).ToList(),
                Fondos = fondoImg.Where(e => e.Id_Juego == juego.Id).Select(fondo => new GJFondoImgDTO_Get
                {
                    Id = fondo.Id,
                    Img = fondo.Img,
                    Id_Juego = fondo.Id_Juego
                }).ToList(),
                Guias = guias.Where(e => e.Id_Juego == juego.Id).Select(guia => new GJRepoGuiaDTO
                {
                    Id = guia.Id,
                    Nombre = guia.Nombre,
                    Orden = guia.Orden,
                    Id_Juego= guia.Id_Juego,
                    GuiaUsuario = guiasUsuario.Where(e => e.Id_Guia == guia.Id).Select(gu => new GJGuiaUsuarioDTO
                    {
                        Id_Guia = gu.Id_Guia,
                        Id_Usuario = gu.Id_Usuario,
                        Estado = gu.Estado,
                    }).ToList(),
                    Aventuras = aventuras.Where(e => e.Id_Guia == guia.Id).Select(aventura => new GJRepoAventuraDTO
                    {
                        Id = aventura.Id,
                        Descripcion = aventura.Descripcion, 
                        Orden = aventura.Orden,
                        Id_Guia = aventura.Id_Guia, 
                        AventuraUsuario = aventurasUsuario.Where(e => e.Id_Aventura == aventura.Id).Select(au => new GJAventuraUsuarioDTO
                        {
                            Id_Aventura = au.Id_Aventura,
                            Id_Usuario = au.Id_Usuario,
                            Estado = au.Estado,
                        }).ToList(),
                        AventurasImg = aventurasImg.Where(e => e.Id_Aventura == aventura.Id).Select(aventuraImg => new GJAventuraImgDTO_Get
                        {
                            Id = aventuraImg.Id,
                            Img = aventuraImg.Img,
                            Orden = aventuraImg.Orden,
                            Id_Aventura = aventuraImg.Id_Aventura,
                        }).ToList(),
                    }).ToList(),
                }).ToList()
            }).ToList();

            return dto;
        }
    }
}
