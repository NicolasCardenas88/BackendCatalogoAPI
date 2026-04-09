using BackendCatalogoAXA.Model.Dto.DtoBalanceo;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IBalanceoData
    {
        Task<List<BalanceoServicioDto>> getAllAsync();
    }
}
