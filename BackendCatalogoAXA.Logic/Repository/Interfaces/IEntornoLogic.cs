using BackendCatalogoAXA.Model.Dto.DtoEntorno;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IEntornoLogic
    {
        Task<List<EntornoDto>> GetAllAsync();
        Task<bool> RegisterEntornoAsync(CreateEntornoDto createEntornoDto);

    }
}
