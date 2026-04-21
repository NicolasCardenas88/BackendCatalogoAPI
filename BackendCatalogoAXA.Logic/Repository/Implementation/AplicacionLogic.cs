using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using BackendCatalogoAXA.Model.Repository.Interfaces;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class AplicacionLogic(IAplicacionData data,IRegisterData register,
        IValidadationService validadationService,
        IMapper mapper
        ) : IAplicacionLogic
    {
        private readonly IAplicacionData _data = data;
        private readonly IRegisterData _register = register;
        private readonly IValidadationService _validationService = validadationService;
        private readonly IMapper _mapper = mapper;

        public async Task<List<AplicacionDto>> getAllAsync()
        {
            return await _data.getAllAsync();
        }

        #region Crear Aplicacion
        public async Task<bool> RegisterAplicacionAsync(CreateAplicacionDto createAplicacionDto)
        {
            await _validationService.ValidateAsync(createAplicacionDto);
            await _register.RegisterLogicAsync(_mapper.Map<Aplicacion>(createAplicacionDto));
            return true;
        }
        #endregion
    }
}
