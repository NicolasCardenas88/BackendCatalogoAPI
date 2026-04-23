using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class RepositorioColeccionData(CatalogoServiciosAxaContext context) : IRepositorioColeccionData
    {
        private readonly CatalogoServiciosAxaContext _context = context;

        public async Task<List<RepositorioColeccion>> GetAllAsync()
        {
            return await _context.RepositorioColeccions
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
