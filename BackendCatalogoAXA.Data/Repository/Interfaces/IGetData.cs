
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Model.Dto.DtoFiltroServicio;
using BackendCatalogoAXA.Model.Dto.DtoServicio;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IGetData
    {
        Task <DetailsServicioDto> FindServicioByIdAsync (int id);
        Task<IEnumerable<DetailsServicioDto>> FindServiciosByFiltroAsync(FiltroServicioDto filtro);
    }
}
