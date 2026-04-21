using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IMetodoHttpLogic
    {
        Task<List<MetodoHttpDto>> GetAllAsync();
        Task<bool> RegisterMetodoHttpAsync(CreateMetodoHttpDto createMetodoHttpDto);

    }
}
