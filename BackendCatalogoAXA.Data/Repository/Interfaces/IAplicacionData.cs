using BackendCatalogoAXA.Model.Dto.DtoAplicacion;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IAplicacionData
    {
        Task<List<AplicacionDto>> getAllAsync();
    }
}
