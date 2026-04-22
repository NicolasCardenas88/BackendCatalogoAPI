using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using BackendCatalogoAXA.Model.Repository.Interfaces;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ApiManagerLogic(IApiManagerData data, 
        IRegisterData register,
        IValidadationService validadationService,
        IMapper mapper) : IApiManagerLogic
    {
        private readonly IApiManagerData _data = data;
        private readonly IRegisterData _register = register;
        private readonly IValidadationService _validationService = validadationService;
        private readonly IMapper _mapper = mapper;
        public async Task<List<ApiManagerDto>> getAllAsync()
        {
            return await _data.getAllAsync();

        }

        #region Crear APIManager
        public async Task<bool> RegisterApiManagerAsync(CreateApiManagerDto createApiManagerDto)
        {
            await _validationService.ValidateAsync(createApiManagerDto);
            await _register.RegisterLogicAsync(_mapper.Map<Apimanager>(createApiManagerDto));
            return true;
        }
        #endregion
    }
}
