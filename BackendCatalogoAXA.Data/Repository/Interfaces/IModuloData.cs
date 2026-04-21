using BackendCatalogoAXA.Model.Dto.Modulo;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IModuloData
    {
        Task<List<ModuloDto>> GetAllAsync();
    }
}
