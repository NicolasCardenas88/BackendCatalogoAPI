using BackendCatalogoAXA.Model.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Model.Dto.DtoFiltroServicio;
using BackendCatalogoAXA.Model.Dto.DtoServicio;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IServiceLogic 
    {
        Task<DetailsServicioDto> FindServicioByIdAsync(int id);
        Task<IEnumerable<DetailsServicioDto>> FindServiciosByFiltroAsync(FiltroServicioDto filtro);
        Task<bool> RegisterServiceAsync(CrearServicioDto crearServicioDto);

    }
}
