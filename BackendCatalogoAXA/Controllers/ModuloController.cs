using BackendCatalogoAXA.Model.Dto.DtoModulo;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ModuloController (IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("servicio/{servicioId}/modulo")]
        public async Task<IActionResult>  CreateModulo (int servicioId, [FromBody] CreateModuloDto createModuloDto)
        {
            await _registerLogic.RegisterLogAsync<CreateModuloDto, Modulo, ServicioModulo>(
            createModuloDto,
            servicioId,
            (servicioId, moduloId) => new ServicioModulo { ServicioId = servicioId, ModuloId = moduloId });
            return Ok(createModuloDto);
        }
    }
}
