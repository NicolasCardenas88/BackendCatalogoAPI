using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoLog;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class LogLogic(ILogData data) : ILogLogic
    {

        private readonly ILogData _data = data;

        public async Task<List<LogDto>> GetAllAsync()
        {
            return await _data.GetAllAsync();
        }
    }
}