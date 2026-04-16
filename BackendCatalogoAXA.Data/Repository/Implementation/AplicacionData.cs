using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoActivo;
using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using BackendCatalogoAXA.Model.Dto.DtoEstado;
using BackendCatalogoAXA.Model.Dto.DtoFramework;
using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;
using BackendCatalogoAXA.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class AplicacionData(CatalogoServiciosAxaContext context) : IAplicacionData
    {

        private readonly CatalogoServiciosAxaContext _context = context;
        public async Task<List<AplicacionDto>> getAllAsync()
        {
            var aplicacion = await _context.Aplicacions.AsNoTracking().ToListAsync();
            return aplicacion.Select(a => MapToDto(a)).ToList();
        }

        private AplicacionDto MapToDto(Aplicacion a)
        {
            return new AplicacionDto
            {
                Codigo = a.Codigo,
                Activo = ConvertActivo(a.Activo),
                NombreApp = a.NombreApp,
                DescripcionFuncional = a.DescripcionFuncional,
                Estado = ConvertEstado(a.Estado),
                Framework = ConvertFramework(a.Framework),
                URLTST = a.Urltst,
                URLUAT = a.Urluat,
                URLProd = a.Urlprod,
                UnidadNegocio = ConvertUniNegocio(a.UnidadNegocio)
            };
        }

        private ActivoDto ConvertActivo(Activo activo)
        {
            if (activo == null) return null;
            return new ActivoDto
            {
                Codigo = activo.Codigo,
                Nombre = activo.Nombre
            };
        }

        public EstadoDto ConvertEstado(Estado estado)
        {
            if (estado == null) return null;
            return new EstadoDto
            {
                Nombre = estado.Nombre
            };
        }

        public FrameworkDto ConvertFramework(Framework framework)
        {
            if (framework == null) return null;
            return new FrameworkDto
            {
                Nombre = framework.Nombre
            };
        }

        public UnidadNegocioDto ConvertUniNegocio(UnidadNegocio uniNegocio)
        {
            if (uniNegocio == null) return null;
            return new UnidadNegocioDto
            {
                Nombre = uniNegocio.Nombre
            };
        }
    }
}
