using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class MetodoHttpController (IMetodoHttpLogic metLogic) : ControllerBase
    {

        private readonly IMetodoHttpLogic _metLogic = metLogic;

        [HttpPost("/metodohttp/V1")]
        public async Task<CreateMetodoHttpDto> CreateMetodoHttp([FromBody] CreateMetodoHttpDto createMetodoHttpDto)
        {
            var result = await _metLogic.RegisterMetodoHttpAsync(createMetodoHttpDto);
            return createMetodoHttpDto;
        }

        [HttpGet("/metodohttp/V1")]
        public async Task<IActionResult> GetMetodoHttp()
        {
            var result = await _metLogic.GetAllAsync();
            return Ok(result);
        }

    }
}
