using BackendCatalogoAXA.Model.Dto.DtoFramework;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class FrameworkController (IRegisterLogic registerLogic, IFrameworkLogic frameworkLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IFrameworkLogic _frameworkLogic = frameworkLogic;

        [HttpPost ("/framework/V1")]
        public async Task<CreateFrameworkDto> CreateFramework([FromBody] CreateFrameworkDto createFrameworkDto)
        {
            var result = await _registerLogic.RegisterFrameworkAsync(createFrameworkDto);
            return createFrameworkDto;
        }

        [HttpGet ("/framework/V1")]
        public async Task<IActionResult> GetFramework()
        {
            var result = await _frameworkLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
