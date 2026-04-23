
using BackendCatalogoAXA.Model.Dto.Modulo;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IModuloLogic
    {
        Task<List<ModuloDto>> GetAllAsync();
    }
}
