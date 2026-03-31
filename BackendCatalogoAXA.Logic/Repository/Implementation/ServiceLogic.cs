using BackendCatalogoAXA.Model.Dto.DtoFiltroServicio;
using BackendCatalogoAXA.Model.Dto.DtoServicio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Data.Repository.Interfaces;


namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ServiceLogic(IGetData getData) : IServiceLogic
    {
        private readonly IGetData _getData = getData;


        public async Task<DetailsServicioDto> FindServicioByIdAsync(int id)
        {
            return await _getData.FindServicioByIdAsync(id);
           
        }
        public async Task<IEnumerable<DetailsServicioDto>> FindServiciosByFiltroAsync(FiltroServicioDto filtro)
        {
            return await _getData.FindServiciosByFiltroAsync(filtro);
        }

    }
}
