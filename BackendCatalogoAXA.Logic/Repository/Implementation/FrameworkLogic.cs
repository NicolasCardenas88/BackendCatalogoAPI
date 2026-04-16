using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoFramework;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class FrameworkLogic(IFrameworkData data) : IFrameworkLogic
    {
        private readonly IFrameworkData _data = data;
        public async Task<List<FrameworkDto>> GetAllAsync()
        {
            return await _data.getAllAsync();
        }
    }
}
