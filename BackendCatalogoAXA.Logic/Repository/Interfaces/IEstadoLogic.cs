using BackendCatalogoAXA.Model.Dto.DtoEstado;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IEstadoLogic
    {
        Task<List<EstadoDto>> GetAllAsync();
    }
}
