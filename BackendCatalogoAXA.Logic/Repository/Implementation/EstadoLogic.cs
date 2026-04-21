
using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoEstado;
using BackendCatalogoAXA.Model.Repository.Interfaces;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class EstadoLogic(IEstadoData data, IRegisterData register,
        IValidadationService validadationService,
        IMapper mapper
        ) : IEstadoLogic
    {

        private readonly IEstadoData _data = data;
        private readonly IRegisterData _register = register;
        private readonly IValidadationService _validationService = validadationService;
        private readonly IMapper _mapper = mapper;

        public async Task<List<EstadoDto>> GetAllAsync()
        {
            return await _data.GetAllAsync();
        }
        #region Crear Estado
        public async Task<bool> RegisterEstadoAsync(CreateEstadoDto createEstadoDto)
        {
            await _validationService.ValidateAsync(createEstadoDto);
            await _register.RegisterLogicAsync(_mapper.Map<Estado>(createEstadoDto));
            return true;
        }
        #endregion
    }
}
