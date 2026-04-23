using BackendCatalogoAXA.Model.Dto.DtoSistemaOperativo;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class SistemaOperativoController(IRegisterLogic registerLogic, ISistemaOperativoLogic sisOperativoLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly ISistemaOperativoLogic _sisOperativoLogic = sisOperativoLogic;

        [HttpPost("/sistemaOperativo/V1")]
        public async Task<IActionResult> CreateSistemaOperativo([FromBody] CreateSistemaOperativoDto createSistemaOperativoDto)
        {
            var result = await _registerLogic.RegisterSistemaOperativoAsync(createSistemaOperativoDto);
            return Ok(createSistemaOperativoDto);
        }

        [HttpGet("/sistemaOperativo/V1")]
        public async Task<IActionResult> GetSisOperativo()
        {
            var result = await _sisOperativoLogic.GetAllAsync();
            return Ok(result);
        }

    }
}
