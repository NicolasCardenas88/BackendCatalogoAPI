using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class UnidadNegocioController (IRegisterLogic registerLogic, IUnidadNegocioLogic uniNegocioLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IUnidadNegocioLogic _uniNegocioLogic = uniNegocioLogic;

        [HttpPost("/unidadNegocio/V1")]
        public async Task<CreateUnidadNegocioDto> CreateUnidadNegocio([FromBody] CreateUnidadNegocioDto createUnidadNegocioDto)
        {
            var result = await _registerLogic.RegisterUnidadNegocioAsync(createUnidadNegocioDto);
            return createUnidadNegocioDto;
        }

        [HttpGet("/unidadNegocio/V1")]
        public async Task<IActionResult> GetUnidadNegocio()
        {
            var result = await _uniNegocioLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
