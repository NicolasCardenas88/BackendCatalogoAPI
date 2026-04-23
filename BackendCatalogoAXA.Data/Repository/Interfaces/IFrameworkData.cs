using BackendCatalogoAXA.Model.Dto.DtoFramework;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IFrameworkData
    {
        Task<List<FrameworkDto>> getAllAsync();
    }
}
