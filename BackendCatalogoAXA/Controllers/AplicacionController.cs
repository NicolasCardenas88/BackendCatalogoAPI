using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class AplicacionController(IRegisterLogic registerLogic, IAplicacionLogic appLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IAplicacionLogic _appLogic = appLogic;

        [HttpPost("/aplicacion/V1")]
        public async Task<CreateAplicacionDto> CreateAplicacion([FromBody] CreateAplicacionDto createAplicacionDto)
        {
            var result = await _registerLogic.RegisterAplicacionAsync(createAplicacionDto);
            return createAplicacionDto;

        }

        [HttpGet("/aplicacion/V1")]
        public async Task<IActionResult> GetAplicacion()
        {
            var result = await _appLogic.getAllAsync();
            return Ok(result);
        }
    }
}
