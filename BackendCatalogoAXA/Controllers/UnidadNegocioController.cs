using BackendCatalogoAXA.Data.Dto.DtoEstado;
using BackendCatalogoAXA.Data.Dto.DtoUnidadNegocio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class UnidadNegocioController (IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createestado/")]
        public async Task<CreateUnidadNegocioDto> CreateEstado([FromBody] CreateUnidadNegocioDto createUnidadNegocioDto)
        {
            var result = await _registerLogic.RegisterUnidadNegocioAsync(createUnidadNegocioDto);
            return createUnidadNegocioDto;
        }
    }
}
