using BackendCatalogoAXA.Data.Dto.DtoAplicacion;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class AplicacionController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createaplicacion/")]
        public async Task<CreateAplicacionDto> CreateAplicacion([FromBody] CreateAplicacionDto createAplicacionDto)
        {
            var result = await _registerLogic.RegisterAplicacionAsync(createAplicacionDto);
            return createAplicacionDto;
            
        }
    }
}
