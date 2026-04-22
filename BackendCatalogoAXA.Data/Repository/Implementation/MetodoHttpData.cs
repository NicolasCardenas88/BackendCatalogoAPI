using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class MetodoHttpData(CatalogoServiciosAxaContext context) : IMetodoHttpData
    {
        private readonly CatalogoServiciosAxaContext _context = context;
        public async Task<List<MetodoHttpDto>> GetAllAsync()
        {
            return await _context.MetodoHttps.AsNoTracking().Select(m => new MetodoHttpDto
            {
                Nombre = m.Nombre
            })
            .ToListAsync();
        }
    }
}
