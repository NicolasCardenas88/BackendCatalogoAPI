using BackendCatalogoAXA.Model.Dto.DtoAmbiente;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IAmbienteData
    {
        Task<List<AmbienteDto>> getAllAsync();
    }
}
