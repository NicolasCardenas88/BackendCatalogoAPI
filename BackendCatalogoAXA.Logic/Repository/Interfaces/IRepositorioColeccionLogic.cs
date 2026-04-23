
using BackendCatalogoAXA.Model.Dto.DtoRepositorioColeccion;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IRepositorioColeccionLogic
    {
        Task<List<RepositorioColeccionDto>> GetAllAsync();
    }
}
