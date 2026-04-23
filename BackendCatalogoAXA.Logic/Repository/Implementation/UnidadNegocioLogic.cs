using AutoMapper;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class UnidadNegocioLogic(IUnidadNegocioData data, IMapper mapper) : IUnidadNegocioLogic
    {

        private readonly IUnidadNegocioData _uniNegocioData = data;
        private readonly IMapper _mapper = mapper;
        public async Task<List<UnidadNegocioDto>> GetAllAsync()
        {
            var uniNegocio = await _uniNegocioData.GetAllAsync();
            return _mapper.Map<List<UnidadNegocioDto>>(uniNegocio);
        }
    }
}
