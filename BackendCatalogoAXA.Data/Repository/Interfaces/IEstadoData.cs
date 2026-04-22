using BackendCatalogoAXA.Model.Dto.DtoEstado;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IEstadoData
    {
        Task<List<EstadoDto>> GetAllAsync();
    }
}
