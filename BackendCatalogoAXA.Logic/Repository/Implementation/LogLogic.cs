using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoLog;
using BackendCatalogoAXA.Model.Repository.Interfaces;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class LogLogic(ILogData data, IRegisterData register,
        IValidadationService validadationService,
        IMapper mapper
        ) : ILogLogic
    {

        private readonly ILogData _data = data;
        private readonly IRegisterData _register = register;
        private readonly IValidadationService _validationService = validadationService;
        private readonly IMapper _mapper = mapper;

        public async Task<List<LogDto>> GetAllAsync()
        {
            return await _data.GetAllAsync();
        }
        #region Crear Log
        public async Task<bool> RegisterLogAsync(CreateLogDto dto)
        {
            var log = _mapper.Map<Log>(dto);
            await _register.RegisterLogicAsync(log);

            var servicioLog = new ServicioLog
            {
                LogId = log.LogId,
                ServicioId = (int)dto.ServicioId
            };

            await _register.RegisterLogicAsync(servicioLog);

            return true;
        }


        #endregion
    }
}