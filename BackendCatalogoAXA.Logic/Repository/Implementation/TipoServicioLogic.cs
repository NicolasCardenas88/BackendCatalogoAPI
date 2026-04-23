using AutoMapper;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoTipoServicio;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class TipoServicioLogic(ITipoServicioData data, IMapper mapper) : ITipoServicioLogic
    {

        private readonly ITipoServicioData _tipoServData = data;
        private readonly IMapper _mapper = mapper;
        public async Task<List<TipoServicioDto>> GetAllAsync()
        {
            var tipoServ = await _tipoServData.GetAllAsync();
            return _mapper.Map<List<TipoServicioDto>>(tipoServ);
        }
    }
}
