using BackendCatalogoAXA.Model.Dto.DtoFramework;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IFrameworkLogic
    {
        Task<List<FrameworkDto>> GetAllAsync();
        Task<bool> RegisterFrameworkAsync(CreateFrameworkDto createFrameworkDto);

    }
}
