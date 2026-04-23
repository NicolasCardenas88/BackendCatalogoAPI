using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class MotorDBData(CatalogoServiciosAxaContext context) : IMotorDBData
    {
        private readonly CatalogoServiciosAxaContext _context = context;

        public async Task<List<MotorBd>> GetAllAsync()
        {
            return await _context.MotorBds
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
