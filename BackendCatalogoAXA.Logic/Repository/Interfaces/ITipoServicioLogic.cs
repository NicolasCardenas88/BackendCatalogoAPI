using BackendCatalogoAXA.Model.Dto.DtoTipoServicio;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface ITipoServicioLogic
    {
        Task<List<TipoServicioDto>> GetAllAsync();
    }
}
