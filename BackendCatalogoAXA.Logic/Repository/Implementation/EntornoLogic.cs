using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoEntorno;
using BackendCatalogoAXA.Model.Repository.Interfaces;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class EntornoLogic(IEntornoData data, IRegisterData register,
        IValidadationService validadationService,
        IMapper mapper) : IEntornoLogic
    {
        private readonly IEntornoData _data = data;
        private readonly IRegisterData _register = register;
        private readonly IValidadationService _validationService = validadationService;
        private readonly IMapper _mapper = mapper;
        public async Task<List<EntornoDto>> GetAllAsync()
        {
            return await _data.GetAllAsync();
        }

        #region Crear Entorno
        public async Task<bool> RegisterEntornoAsync(CreateEntornoDto createEntornoDto)
        {
            await _validationService.ValidateAsync(createEntornoDto);
            var result = await _register.RegisterLogicAsync(_mapper.Map<Entorno>(createEntornoDto));
            return true;
        }
        #endregion
    }
}
