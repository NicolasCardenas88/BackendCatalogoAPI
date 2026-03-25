using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class UnidadNegocioController (IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createunidadnegocio/")]
        public async Task<CreateUnidadNegocioDto> CreateUnidadNegocio([FromBody] CreateUnidadNegocioDto createUnidadNegocioDto)
        {
            var result = await _registerLogic.RegisterUnidadNegocioAsync(createUnidadNegocioDto);
            return createUnidadNegocioDto;
        }
    }
}
