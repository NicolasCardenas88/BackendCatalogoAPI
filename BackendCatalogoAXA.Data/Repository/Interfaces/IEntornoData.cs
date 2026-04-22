using BackendCatalogoAXA.Model.Dto.DtoEntorno;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IEntornoData
    {
        Task<List<EntornoDto>> GetAllAsync();
    }
}
