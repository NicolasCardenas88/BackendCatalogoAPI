using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IMotorDBData
    {
        Task<List<MotorBd>> GetAllAsync();
    }
}
