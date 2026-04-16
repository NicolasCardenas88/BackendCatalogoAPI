using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoEntorno;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class EntornoLogic(IEntornoData data) : IEntornoLogic
    {
        private readonly IEntornoData _data = data;
        public async Task<List<EntornoDto>> GetAllAsync()
        {
            return await _data.GetAllAsync();
        }
    }
}
