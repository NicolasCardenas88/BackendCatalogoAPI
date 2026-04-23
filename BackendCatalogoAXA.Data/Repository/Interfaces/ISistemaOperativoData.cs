using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface ISistemaOperativoData
    {
        Task<List<SistemaOperativo>> GetAllAsync();
    }
}
