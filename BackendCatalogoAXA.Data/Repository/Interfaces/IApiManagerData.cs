using BackendCatalogoAXA.Model.Dto.DtoApimanager;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IApiManagerData
    {
        Task<List<ApiManagerDto>> getAllAsync();
    }
}
