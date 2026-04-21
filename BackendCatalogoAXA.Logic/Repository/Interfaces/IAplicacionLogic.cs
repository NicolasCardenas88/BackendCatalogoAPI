using BackendCatalogoAXA.Model.Dto.DtoAplicacion;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IAplicacionLogic
    {
        Task<List<AplicacionDto>> getAllAsync();
        Task<bool> RegisterAplicacionAsync(CreateAplicacionDto createAplicacionDto);

    }
}
