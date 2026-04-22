using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IMetodoHttpData
    {
        Task<List<MetodoHttpDto>> GetAllAsync();
    }
}
