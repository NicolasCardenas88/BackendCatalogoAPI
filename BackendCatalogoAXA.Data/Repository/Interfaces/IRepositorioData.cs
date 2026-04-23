using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IRepositorioData
    {
        Task<List<Repositorio>> GetAllAsync();
    }
}
