using BackendCatalogoAXA.Model.Dto.DtoTipoServicio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class TipoServicioController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createtiposervicio/")]
        public async Task<CreateTipoServicioDto> CreateTipoServicio([FromBody] CreateTipoServicioDto createTipoServicioDto)
        {
            var result = await _registerLogic.RegisterTipoServicioAsync(createTipoServicioDto);
            return createTipoServicioDto;
        }
    }
}
