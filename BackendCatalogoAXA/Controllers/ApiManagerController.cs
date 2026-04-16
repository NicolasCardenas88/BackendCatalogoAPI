using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ApiManagerController (IRegisterLogic registerLogic, IApiManagerLogic apimLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IApiManagerLogic _apimLogic = apimLogic;

        [HttpPost("/apimanager/V1")]
        public async Task<CreateApiManagerDto> CreateApiManager([FromBody] CreateApiManagerDto createApiManagerDto)
        {
            var result = await _registerLogic.RegisterApiManagerAsync(createApiManagerDto);
            return createApiManagerDto;

        }

        [HttpGet("/apimanager/V1")]
        public async Task<IActionResult> GetApiManager()
        {
            var result = await _apimLogic.getAllAsync();
            return Ok(result);
        }
    }
}
