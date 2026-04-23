using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class UnidadNegocioData(CatalogoServiciosAxaContext context) : IUnidadNegocioData
    {
        private readonly CatalogoServiciosAxaContext _context = context;

        public async Task<List<UnidadNegocio>> GetAllAsync()
        {
            return await _context.UnidadNegocios
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
