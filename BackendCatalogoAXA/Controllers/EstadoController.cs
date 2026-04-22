using BackendCatalogoAXA.Model.Dto.DtoEstado;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class EstadoController(IRegisterLogic registerLogic, IEstadoLogic estadoLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IEstadoLogic _estadoLogic = estadoLogic;

        [HttpPost("/estado/V1")]
        public async Task <CreateEstadoDto> CreateEstado([FromBody] CreateEstadoDto createEstadoDto)
        {
            var result = await _registerLogic.RegisterEstadoAsync(createEstadoDto);
            return createEstadoDto;
        }

        [HttpGet("/estado/V1")]
        public async Task<IActionResult> GetEstado()
        {
            var result = await _estadoLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
