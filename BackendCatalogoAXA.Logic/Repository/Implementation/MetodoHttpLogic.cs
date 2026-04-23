using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class MetodoHttpLogic(IMetodoHttpData data) : IMetodoHttpLogic
    {

        private readonly IMetodoHttpData _data = data;
        public async Task<List<MetodoHttpDto>> GetAllAsync()
        {
            return await _data.GetAllAsync();
        }
    }
}
