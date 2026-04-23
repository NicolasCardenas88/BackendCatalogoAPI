using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface ITipoServicioData
    {
        Task<List<TipoServicio>> GetAllAsync();
    }
}
