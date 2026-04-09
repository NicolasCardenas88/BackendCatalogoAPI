using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoLog;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class LogData(CatalogoServiciosAxaContext context) : ILogData
    {
        private readonly CatalogoServiciosAxaContext _context = context;

        public async Task<List<LogDto>> GetAllAsync()
        {
            var log = await _context.Logs.AsNoTracking().ToListAsync();
            return log.Select(l => MapToDto(l)).ToList();
        }

        private LogDto MapToDto(Log l)
        {
            return new LogDto
            {
                Codigo = l.Codigo,
                RutaLog = l.RutaLog
            };
        }
    }
}
