using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class TipoServicioData(CatalogoServiciosAxaContext context) : ITipoServicioData
    {

        private readonly CatalogoServiciosAxaContext _context = context;

        public async Task<List<TipoServicio>> GetAllAsync()
        {
            return await _context.TipoServicios
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
