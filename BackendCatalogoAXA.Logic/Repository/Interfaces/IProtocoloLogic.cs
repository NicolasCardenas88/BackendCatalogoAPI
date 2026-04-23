using BackendCatalogoAXA.Model.Dto.DtoProtocolo;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IProtocoloLogic
    {
        Task<List<ProtocoloDto>> GetAllAsync();
    }
}
