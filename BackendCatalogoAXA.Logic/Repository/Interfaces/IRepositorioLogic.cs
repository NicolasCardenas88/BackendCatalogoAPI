using BackendCatalogoAXA.Model.Dto.DtoRepositorio;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IRepositorioLogic
    {
        Task<List<RepositorioDto>> GetAllAsync();
    }
}
