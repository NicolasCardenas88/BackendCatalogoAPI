using BackendCatalogoAXA.Model.Dto.DtoMotorDB;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IMotorDBLogic
    {
        Task<List<MotorDbDto>> GetAllAsync();
    }
}
