using BackendCatalogoAXA.Model.Dto.DtoLog;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface ILogData
    {
        Task<List<LogDto>> GetAllAsync();
    }
}
