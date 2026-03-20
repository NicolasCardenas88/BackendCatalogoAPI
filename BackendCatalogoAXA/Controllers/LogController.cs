using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.DtoLog;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class LogController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("servicio/{servicioId}/logs")]
        public async Task<IActionResult> CreateLogForServicio(int servicioId, [FromBody] CreateLogDto createLogDto)
        {
             await _registerLogic.RegisterLogAsync<CreateLogDto, Log, ServicioLog>(
                createLogDto,
                servicioId,
                (servicioId, logId) => new ServicioLog { ServicioId = servicioId, LogId = logId });
            return Ok(createLogDto);
        }

    }
}
