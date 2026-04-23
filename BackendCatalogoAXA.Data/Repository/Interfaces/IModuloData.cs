using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IModuloData
    {
        Task<List<Modulo>> GetAllAsync();
    }
}
