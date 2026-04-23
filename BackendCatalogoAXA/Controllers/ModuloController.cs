using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ModuloController (IRegisterLogic registerLogic, IModuloLogic moduloLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IModuloLogic _moduloLogic = moduloLogic;

        [HttpPost("servicio/modulo")]
        public async Task<CreateModuloDto> CreateModuloAsync ([FromBody] CreateModuloDto createModuloDto)
        {
            var result = await _registerLogic.RegisterModuloAsync(createModuloDto);
            return createModuloDto;
        }

        [HttpGet("servicio/modulo")]
        public async Task<IActionResult> GetModulo()
        {
            var result = await _moduloLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
