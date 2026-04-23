using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class SistemaOperativoData(CatalogoServiciosAxaContext context) : ISistemaOperativoData
    {

        private readonly CatalogoServiciosAxaContext _context = context;
        public async Task<List<SistemaOperativo>> GetAllAsync()
        {
            return await _context.SistemaOperativos
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
