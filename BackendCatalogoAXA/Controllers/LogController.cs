using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoLog;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class LogController(ILogLogic logLogic) : ControllerBase
    {
        private readonly ILogLogic _logLogic = logLogic;


        [HttpPost("servicio/logs/v1")]
        public async Task<CreateLogDto> CreateLogAsync([FromBody] CreateLogDto createLogDto)
        {
            var result = await _logLogic.RegisterLogAsync(createLogDto);
            return createLogDto;
        }

        [HttpGet("logs/V1")]
        public async Task<IActionResult> GetLog()
        {
            var result = await _logLogic.GetAllAsync();
            return Ok(result);
        }
    }
}