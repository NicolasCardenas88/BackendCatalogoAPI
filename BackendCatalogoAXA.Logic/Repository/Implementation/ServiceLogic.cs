using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.DtoFiltroServicio;
using BackendCatalogoAXA.Data.Dto.DtoServicio;
using BackendCatalogoAXA.Data.Mapper.MapperService;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;


namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ServiceLogic(IGetData getData) : IServiceLogic
    {
        private readonly IGetData _getData = getData;


        public async Task<DetailsServicioDto> FindServicioByIdAsync(int id)
        {
            return await _getData.FindServicioByIdAsync(id);
           
        }
        public async Task<List<Servicio>> FindAllServicios()
        {
            var servicio = await _getData.FindAllServicios();
            return servicio;
        }
        public async Task<IEnumerable<DetailsServicioDto>> FindServiciosByFiltroAsync(FiltroServicioDto filtro)
        {
            return await _getData.FindServiciosByFiltroAsync(filtro);
        }

    }
}
