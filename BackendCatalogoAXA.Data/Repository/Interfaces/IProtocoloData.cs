using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IProtocoloData
    {
        Task<List<Protocolo>> GetAllAsync();
    }
}
