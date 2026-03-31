using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoActivo;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ActivoController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("activo/v1/")]
        public async Task<CreateActivoDto> RegisterActivoAsync(CreateActivoDto createActivoDto)
        {
            var result = await _registerLogic.RegisterActivoAsync(createActivoDto);
            return createActivoDto;
        }
    }
}
