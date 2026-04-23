using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ProtocoloData(CatalogoServiciosAxaContext context) : IProtocoloData
    {
        private readonly CatalogoServiciosAxaContext _context = context;
        public async Task<List<Protocolo>> GetAllAsync()
        {
            return await _context.Protocolos
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
