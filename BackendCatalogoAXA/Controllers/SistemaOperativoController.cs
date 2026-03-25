using BackendCatalogoAXA.Model.Dto.DtoSistemaOperativo;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class SistemaOperativoController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        [HttpPost("/createsistemaoperativo/")]
        public async Task<IActionResult> CreateSistemaOperativo([FromBody] CreateSistemaOperativoDto createSistemaOperativoDto)
        {
            var result = await _registerLogic.RegisterSistemaOperativoAsync(createSistemaOperativoDto);
            return Ok(createSistemaOperativoDto);
        }
    }
}
