using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class ApiManagerData(CatalogoServiciosAxaContext context) : IApiManagerData
    {
        private readonly CatalogoServiciosAxaContext _context = context;

        public async Task<List<ApiManagerDto>> getAllAsync()
        {
            var apiManagers = await _context.Apimanagers.AsNoTracking().ToListAsync();
            return apiManagers.Select(a => MapToDto(a)).ToList();
        }

        private ApiManagerDto MapToDto(Apimanager am)
        {
            return new ApiManagerDto
            {
                Codigo = am.Codigo,
                Catalogo = am.Codigo,
                NombreApi = am.NombreApi,
                Version = am.Version,
                Recurso = am.Recurso,
                MetodoHttp = ConvertMetodoHttp(am.MetodoHttp),
                Url = am.Url,
                Ambiente = ConvertAmbiente(am.Ambiente),
            };
        }

        private MetodoHttpDto ConvertMetodoHttp(MetodoHttp metodoHttp)
        {
            if (metodoHttp == null) return null;
            return new MetodoHttpDto
            {
                Nombre = metodoHttp.Nombre
            };
        }

        private AmbienteDto ConvertAmbiente(Ambiente ambiente)
        {
            if (ambiente == null) return null;
            return new AmbienteDto
            {
                Codigo = ambiente.Codigo,
                Descripcion = ambiente.Descripcion
            };
        }
    }
}
