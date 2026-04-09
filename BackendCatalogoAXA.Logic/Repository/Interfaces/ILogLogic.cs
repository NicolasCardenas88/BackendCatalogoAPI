
using BackendCatalogoAXA.Model.Dto.DtoLog;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface ILogLogic
    {
        Task<List<LogDto>> GetAllAsync();
    }
}
