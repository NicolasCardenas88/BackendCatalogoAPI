using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ApiManagerController (IApiManagerLogic apimLogic) : ControllerBase
    {
        
        private readonly IApiManagerLogic _apimLogic = apimLogic;

        [HttpPost("/apimanager/V1")]
        public async Task<CreateApiManagerDto> CreateApiManager([FromBody] CreateApiManagerDto createApiManagerDto)
        {
            var result = await apimLogic.RegisterApiManagerAsync(createApiManagerDto);
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
