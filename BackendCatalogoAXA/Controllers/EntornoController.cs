using BackendCatalogoAXA.Model.Dto.DtoEntorno;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class EntornoController(IRegisterLogic registerLogic, IEntornoLogic entornoLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IEntornoLogic _entornoLogic = entornoLogic;

        [HttpPost("/entorno/V1")]
        public async Task<CreateEntornoDto> CreateEntornoAsync([FromBody] CreateEntornoDto createEntornoDto)
        {
            var result = await _registerLogic.RegisterEntornoAsync(createEntornoDto);
            return createEntornoDto;
        }

        [HttpGet("/entorno/V1")]
        public async Task<IActionResult> GetEntorno()
        {
            var result = await _entornoLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
