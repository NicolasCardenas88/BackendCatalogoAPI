

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IValidadationService
    {
        Task ValidateAsync <T>(T dto);
    }
}
