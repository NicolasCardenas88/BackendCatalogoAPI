using BackendCatalogoAXA.Model.Dto.DtoLog;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class LogController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("servicio/logs")]
        public async Task<IActionResult> CreateLogAsync([FromBody] CreateLogDto createLogDto)
        {
            var result = await _registerLogic.RegisterLogAsync(createLogDto);
            return Ok(createLogDto);
        }

    }
}
