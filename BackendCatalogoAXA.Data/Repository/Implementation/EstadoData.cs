using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoEstado;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class EstadoData(CatalogoServiciosAxaContext context) : IEstadoData
    {
        private readonly CatalogoServiciosAxaContext _context = context;
        public async Task<List<EstadoDto>> GetAllAsync()
        {
            var estado = await _context.Estados.AsNoTracking().ToListAsync();
            return estado.Select(e => MapToDto(e)).ToList();
        }

        private EstadoDto MapToDto(Estado e)
        {
            return new EstadoDto
            {
                Nombre = e.Nombre
            };
        }
    }
}
