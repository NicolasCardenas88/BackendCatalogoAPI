using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class RepositorioData(CatalogoServiciosAxaContext context) : IRepositorioData
    {
        private readonly CatalogoServiciosAxaContext _context = context;

        public async Task<List<Repositorio>> GetAllAsync()
        {
            return await _context.Repositorios
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
