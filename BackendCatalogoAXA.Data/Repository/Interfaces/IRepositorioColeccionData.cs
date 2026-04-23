using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IRepositorioColeccionData
    {
        Task<List<RepositorioColeccion>> GetAllAsync();
    }
}
