using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ApiManagerController (IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createapimanager/")]
        public async Task<CreateApiManagerDto> CreateApiManager([FromBody] CreateApiManagerDto createApiManagerDto)
        {
            var result = await _registerLogic.RegisterApiManagerAsync(createApiManagerDto);
            return createApiManagerDto;

        }
           
    }
}
