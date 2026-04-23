using AutoMapper;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoSistemaOperativo;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class SistemaOperativoLogic(ISistemaOperativoData data, IMapper mapper) : ISistemaOperativoLogic
    {
        private readonly ISistemaOperativoData _sisOperativo = data;
        private readonly IMapper _mapper = mapper;
        public async Task<List<SistemaOperativoDto>> GetAllAsync()
        {
            var sisOperativo = await _sisOperativo.GetAllAsync();
            return _mapper.Map<List<SistemaOperativoDto>>(sisOperativo);
        }
    }
}
