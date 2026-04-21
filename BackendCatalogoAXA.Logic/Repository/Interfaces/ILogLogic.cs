
using BackendCatalogoAXA.Model.Dto.DtoLog;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface ILogLogic
    {
        Task<List<LogDto>> GetAllAsync();
        Task<bool> RegisterLogAsync(CreateLogDto createLogDto);

    }
}
