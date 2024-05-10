using BibliotecaF1.DTOs;
using BibliotecaF1.Models;

namespace BibliotecaF1.Utils
{
    public class MapperF1
    {
        public F1PaisGetDTO ToF1PaisDto(F1PaisModel entity)
        {
            return new F1PaisGetDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                UrlBandera = entity.UrlBandera,
            };
        }

        public F1PaisModel ToF1PaisInsert(F1PaisPostPutDTO dto)
        {
            return new F1PaisModel
            {
                Nombre = dto.Nombre,
                UrlBandera = dto.UrlBandera,
            };
        }

        public F1PaisModel ToF1PaisUpdate(int Id, F1PaisPostPutDTO dto)
        {
            return new F1PaisModel
            {
                Id = Id,
                Nombre = dto.Nombre,
                UrlBandera = dto.UrlBandera,
            };
        }

        public F1PilotoGetDTO ToF1PilotoDto(F1PilotoModel entity)
        {
            return new F1PilotoGetDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                FechaNaci = entity.FechaNaci,
                Estatura = entity.Estatura,
                Peso = entity.Peso,
                Dorsal = entity.Dorsal,
                UrlPerfil = entity.UrlPerfil,
                EstaVivo = entity.EstaVivo,
                Puntos = entity.Puntos,
                IdPais = entity.IdPais,
                IdEscuderia = entity.IdEscuderia,
            };
        }

        public F1PilotoModel ToF1PilotoInsert(F1PilotoPostPutDTO dto)
        {
            return new F1PilotoModel
            {
                Nombre = dto.Nombre,
                FechaNaci = dto.FechaNaci,
                Estatura = dto.Estatura,
                Peso = dto.Peso,
                Dorsal = dto.Dorsal,
                UrlPerfil = dto.UrlPerfil,
                EstaVivo = dto.EstaVivo,
                Puntos = dto.Puntos,
                IdPais = dto.IdPais,
                IdEscuderia = dto.IdEscuderia,
            };
        }

        public F1PilotoModel ToF1PilotoUpdate(int Id, F1PilotoPostPutDTO dto)
        {
            return new F1PilotoModel
            {
                Id = Id,
                Nombre = dto.Nombre,
                FechaNaci = dto.FechaNaci,
                Estatura = dto.Estatura,
                Peso = dto.Peso,
                Dorsal = dto.Dorsal,
                UrlPerfil = dto.UrlPerfil,
                EstaVivo = dto.EstaVivo,
                Puntos = dto.Puntos,
                IdPais = dto.IdPais,
                IdEscuderia = dto.IdEscuderia,
            };
        }

        public F1CircuitoGetDTO ToF1CircuitoDto(F1CircuitoModel entity)
        {
            return new F1CircuitoGetDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                IdPais = entity.IdPais,
            };
        }

        public F1CircuitoModel ToF1CircuitoInsert(F1CircuitoPostPutDTO dto)
        {
            return new F1CircuitoModel
            {
                Nombre = dto.Nombre,
                IdPais = dto.IdPais,
            };
        }

        public F1CircuitoModel ToF1CircuitoUpdate(int Id, F1CircuitoPostPutDTO dto)
        {
            return new F1CircuitoModel
            {
                Id = Id,
                Nombre = dto.Nombre,
                IdPais = dto.IdPais,
            };
        }

        public F1EscuderiaGetDTO ToF1EscuderiaDto(F1EscuderiaModel entity)
        {
            return new F1EscuderiaGetDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                UrlAuto = entity.UrlAuto,
                IdPais = entity.IdPais,
            };
        }

        public F1EscuderiaModel ToF1EscuderiaInsert(F1EscuderiaPostPutDTO dto)
        {
            return new F1EscuderiaModel
            {
                Nombre = dto.Nombre,
                UrlAuto = dto.UrlAuto,
                IdPais = dto.IdPais,
            };
        }

        public F1EscuderiaModel ToF1EscuderiaUpdate(int Id, F1EscuderiaPostPutDTO dto)
        {
            return new F1EscuderiaModel
            {
                Id = Id,
                Nombre = dto.Nombre,
                UrlAuto = dto.UrlAuto,
                IdPais = dto.IdPais,
            };
        }

        public F1CarreraGetDTO ToF1CarreraDto(F1CarreraModel entity)
        {
            return new F1CarreraGetDTO
            {
                Id = entity.Id,
                Fecha = entity.Fecha,
                Clima = entity.Clima,
                IdCircuito = entity.IdCircuito,
            };
        }

        public F1CarreraModel ToF1CarreraInsert(F1CarreraPostPutDTO dto)
        {
            return new F1CarreraModel
            {
                Fecha = dto.Fecha,
                Clima = dto.Clima,
                IdCircuito = dto.IdCircuito,
            };
        }

        public F1CarreraModel ToF1CarreraUpdate(int Id, F1CarreraPostPutDTO dto)
        {
            return new F1CarreraModel
            {
                Id = Id,
                Fecha = dto.Fecha,
                Clima = dto.Clima,
                IdCircuito = dto.IdCircuito,
            };
        }
    }


}
