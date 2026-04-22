using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ModuloController (IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("servicio/modulo")]
        public async Task<CreateModuloDto>  CreateModuloAsync ([FromBody] CreateModuloDto createModuloDto)
        {
            var result = await _registerLogic.RegisterModuloAsync(createModuloDto);
            return createModuloDto;
        }
    }
}
