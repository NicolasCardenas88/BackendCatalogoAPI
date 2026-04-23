using AutoMapper;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoProtocolo;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ProtocoloLogic(IProtocoloData data, IMapper mapper) : IProtocoloLogic
    {
        private readonly IProtocoloData _protocoloData = data;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ProtocoloDto>> GetAllAsync()
        {
            var protocolo = await _protocoloData.GetAllAsync();
            return _mapper.Map<List<ProtocoloDto>>(protocolo);
        }
    }
}
