using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Model.Repository.Interfaces;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class MetodoHttpLogic(IMetodoHttpData data, IRegisterData register,
        IValidadationService validadationService,
        IMapper mapper
        ) : IMetodoHttpLogic
    {

        private readonly IMetodoHttpData _data = data;
        private readonly IRegisterData _register = register;
        private readonly IValidadationService _validationService = validadationService;
        private readonly IMapper _mapper = mapper;

        public async Task<List<MetodoHttpDto>> GetAllAsync()
        {
            return await _data.GetAllAsync();
        }

        #region Crear Metodo Http
        public async Task<bool> RegisterMetodoHttpAsync(CreateMetodoHttpDto createMetodoHttpDto)
        {
            await _validationService.ValidateAsync(createMetodoHttpDto);
            await _register.RegisterLogicAsync(_mapper.Map<MetodoHttp>(createMetodoHttpDto));
            return true;
        }
        #endregion
    }
}
