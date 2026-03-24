using BackendCatalogoAXA.Data.Dto.DtoAmbiente;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class AmbienteController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createambiente/")]
        public async Task<CreateAmbienteDto> CreateAmbienteAsync (CreateAmbienteDto createAmbienteDto)
        {
            var result = await _registerLogic.RegisterAmbienteAsync(createAmbienteDto);
            return createAmbienteDto;
        }
    }
}
