using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using BackendCatalogoAXA.Model.Repository.Interfaces;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class AmbienteLogic(IAmbienteData data,
        IMapper mapper,
        IRegisterData registerData,
        IValidadationService validadationService) : IAmbienteLogic
    {
        private readonly IAmbienteData _data = data;
        private readonly IRegisterData _register = registerData;
        private readonly IValidadationService _validationService = validadationService;
        private readonly IMapper _mapper = mapper;

        public async Task<List<AmbienteDto>> getAllAsync()
        {
            var resp = await _data.getAllAsync();

            return resp.Select(a => new AmbienteDto
            {
                Codigo = a.Codigo,
                Descripcion = a.Descripcion,
            }).ToList();
        }

        #region Crear Ambiente
        public async Task<bool> RegisterAmbienteAsync(CreateAmbienteDto createAmbienteDto)
        {
            await _validationService.ValidateAsync(createAmbienteDto);
            await _register.RegisterLogicAsync(_mapper.Map<Ambiente>(createAmbienteDto));
            return true;
        }
        #endregion
    }
}
