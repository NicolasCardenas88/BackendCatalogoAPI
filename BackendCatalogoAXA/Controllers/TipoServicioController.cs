using BackendCatalogoAXA.Model.Dto.DtoTipoServicio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class TipoServicioController(IRegisterLogic registerLogic, ITipoServicioLogic tipoServLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly ITipoServicioLogic _tipoServLogic = tipoServLogic;

        [HttpPost("/tipoServicio/V1")]
        public async Task<CreateTipoServicioDto> CreateTipoServicio([FromBody] CreateTipoServicioDto createTipoServicioDto)
        {
            var result = await _registerLogic.RegisterTipoServicioAsync(createTipoServicioDto);
            return createTipoServicioDto;
        }

        [HttpGet("/tipoServicio/V1")]
        public async Task<IActionResult> GetTipoServicio()
        {
            var resultado = await _tipoServLogic.GetAllAsync();
            return Ok(resultado);
        }
    }
}
