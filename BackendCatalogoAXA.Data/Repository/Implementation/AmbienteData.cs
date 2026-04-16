using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using Microsoft.EntityFrameworkCore;


namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class AmbienteData(CatalogoServiciosAxaContext context) : IAmbienteData
    {
    private readonly CatalogoServiciosAxaContext _context = context;
        public async Task<List<AmbienteDto>> getAllAsync()
        {
            return await _context.Ambientes.
                AsNoTracking().
                Select(a => new AmbienteDto
                {
                    Codigo = a.Codigo,
                    Descripcion = a.Descripcion
                })
                .ToListAsync();
        }
    }
}