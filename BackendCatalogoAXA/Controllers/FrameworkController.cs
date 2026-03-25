using BackendCatalogoAXA.Model.Dto.DtoFramework;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class FrameworkController (IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost ("/createframework")]
        public async Task<CreateFrameworkDto> CreateFramework([FromBody] CreateFrameworkDto createFrameworkDto)
        {
            var result = await _registerLogic.RegisterFrameworkAsync(createFrameworkDto);
            return createFrameworkDto;
        } 
    }
}
