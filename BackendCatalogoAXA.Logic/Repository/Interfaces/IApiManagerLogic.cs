using BackendCatalogoAXA.Model.Dto.DtoApimanager;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IApiManagerLogic
    {
        Task<List<ApiManagerDto>> getAllAsync();
        Task<bool> RegisterApiManagerAsync(CreateApiManagerDto createApiManagerDto);

    }
}
