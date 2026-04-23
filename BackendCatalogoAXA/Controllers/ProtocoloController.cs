using BackendCatalogoAXA.Model.Dto.DtoProtocolo;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ProtocoloController(IRegisterLogic registerLogic, IProtocoloLogic protocoloLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IProtocoloLogic _protocoloLogic = protocoloLogic;

        [HttpPost ("/protocolo/V1")]
        public async Task<CreateProtocoloDto> CreateProtocolo (CreateProtocoloDto dto)
        {
            var result = await _registerLogic.RegisterProtocoloAsync (dto);
            return dto;
        }

        [HttpGet ("/protocolo/V1")]
        public async Task<IActionResult> GetProtocolo()
        {
            var result = await _protocoloLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
