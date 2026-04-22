using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoFramework;
using BackendCatalogoAXA.Model.Repository.Interfaces;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class FrameworkLogic(IFrameworkData data, IRegisterData register,
        IValidadationService validadationService,
        IMapper mapper
        ) : IFrameworkLogic
    {
        private readonly IFrameworkData _data = data;
        private readonly IRegisterData _register = register;
        private readonly IValidadationService _validationService = validadationService;
        private readonly IMapper _mapper = mapper;
        public async Task<List<FrameworkDto>> GetAllAsync()
        {
            return await _data.getAllAsync();
        }

        #region Crear Framework
        public async Task<bool> RegisterFrameworkAsync(CreateFrameworkDto createFrameworkDto)
        {

            await _validationService.ValidateAsync(createFrameworkDto);
            await _register.RegisterLogicAsync(_mapper.Map<Framework>(createFrameworkDto));
            return true;
        }
        #endregion
    }
}
