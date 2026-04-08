using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoActivo;
using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class AplicacionData(CatalogoServiciosAxaContext context) : IAplicacionData
    {

        private readonly CatalogoServiciosAxaContext _context = context;
        public async Task<List<AplicacionDto>> getAllAsync()
        {
            var aplicacion = await _context.Aplicacions.AsNoTracking().ToListAsync();
            return aplicacion.Select(a =>)
        }

        private AplicacionDto MapToDto(Aplicacion a)
        {
            return new AplicacionDto
            {
                Codigo = a.Codigo,
                Activo = ConvertActivo(a.ActivoId)

            }
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
    }
}
