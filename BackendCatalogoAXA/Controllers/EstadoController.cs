using BackendCatalogoAXA.Data.Dto.DtoEstado;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class EstadoController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createestado/")]
        public async Task <CreateEstadoDto> CreateEstado([FromBody] CreateEstadoDto createEstadoDto)
        {
            var result = await _registerLogic.RegisterEstadoAsync(createEstadoDto);
            return createEstadoDto;
        }

    }
}
