using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoEntorno;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class EntornoData(CatalogoServiciosAxaContext context) : IEntornoData
    {
        private readonly CatalogoServiciosAxaContext _context = context;

        public async Task<List<EntornoDto>> GetAllAsync()
        {
            return await _context.Entornos.AsNoTracking().Select(e => new EntornoDto
            {
                Nombre = e.Nombre
            })
            .ToListAsync();
        }
    }
}
