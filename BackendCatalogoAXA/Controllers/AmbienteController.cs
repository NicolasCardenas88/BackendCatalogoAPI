using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class AmbienteController( IAmbienteLogic ambienteLogic) : ControllerBase
    {
        
        private readonly IAmbienteLogic _ambienteLogic = ambienteLogic;

        [HttpPost("/ambiente/V1")]
        public async Task<CreateAmbienteDto> CreateAmbienteAsync (CreateAmbienteDto createAmbienteDto)
        {
            var result = await _ambienteLogic.RegisterAmbienteAsync(createAmbienteDto);
            return createAmbienteDto;
        }

        [HttpGet("/ambiente/V1")]
        public async Task<IActionResult> GetAmbiente()
        {
            var result = await _ambienteLogic.getAllAsync();
            return Ok(result);
        }
    }
}
