using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class ModuloData(CatalogoServiciosAxaContext context) : IModuloData
    {

        private readonly CatalogoServiciosAxaContext _context = context;
        public async Task<List<Modulo>> GetAllAsync()
        {
            return await _context.Modulos
                .Include(m => m.Aplicacion)
                    .ThenInclude(a => a.Activo)
                .Include(m => m.Aplicacion)
                    .ThenInclude(a => a.Estado)
                .Include(m => m.Aplicacion)
                    .ThenInclude(a => a.Framework)
                .Include(m => m.Aplicacion)
                    .ThenInclude(a => a.UnidadNegocio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
