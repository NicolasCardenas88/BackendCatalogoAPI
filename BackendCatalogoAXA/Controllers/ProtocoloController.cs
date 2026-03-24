using BackendCatalogoAXA.Data.Dto.DtoProtocolo;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ProtocoloController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost ("/createprotocolo/")]
        public async Task<CreateProtocoloDto> CreateProtocolo (CreateProtocoloDto dto)
        {
            var result = await _registerLogic.RegisterProtocoloAsync (dto);
            return dto;
        }
    }
}
