using BackendCatalogoAXA.Model.Dto.DtoAmbiente;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IAmbienteLogic
    {
        Task<List<AmbienteDto>> getAllAsync();
    }
}
