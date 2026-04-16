using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using BackendCatalogoAXA.Model.Dto.Modulo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    //public class ModuloData(CatalogoServiciosAxaContext context) : IModuloData
    //{

    //    private readonly CatalogoServiciosAxaContext _context = context;
    //    public async Task<List<ModuloDto>> GetAllAsync()
    //    {
    //        var modulo = await _context.Modulos.AsNoTracking().ToListAsync();
    //        return modulo.Select(m => MapToDto(m)).ToList();
    //    }

    //    private ModuloDto MapToDto(Modulo m)
    //    {
    //        return new ModuloDto
    //        {
    //            Codigo = m.Codigo,
    //            AplicacionId = ConvertAplicacion(m.Aplicacion),
    //            Nombre = m.Nombre
    //        };
    //    }

    //    private AplicacionDto ConvertAplicacion(Aplicacion aplicacion)
    //    {
    //        if (aplicacion == null) return null;
    //        return new AplicacionDto
    //        {
                
    //        }
    //    }
    //}
}
