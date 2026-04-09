using BackendCatalogoAXA.Model.Dto.DtoLog;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BackendCatalogoAXA.Data.Context;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class LogController(IRegisterLogic registerLogic, ILogLogic logLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly ILogLogic _logLogic = logLogic;

        [HttpPost("/logs/V1/{servicioId}")]
        public async Task<IActionResult> CreateLogForServicio(int servicioId, [FromBody] CreateLogDto createLogDto)
        {
             await _registerLogic.RegisterLogAsync<CreateLogDto, Log, ServicioLog>(
                createLogDto,
                servicioId,
                (servicioId, logId) => new ServicioLog { ServicioId = servicioId, LogId = logId });
            return Ok(createLogDto);
        }

        [HttpGet("/logs/V1")]
        public async Task<IActionResult> GetLog()
        {
            var result = await _logLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
