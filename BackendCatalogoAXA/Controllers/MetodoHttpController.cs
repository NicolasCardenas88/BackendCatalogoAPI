using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class MetodoHttpController (IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly  IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createmetodohttp/")]
        public async Task<CreateMetodoHttpDto> CreateMetodoHttp([FromBody] CreateMetodoHttpDto createMetodoHttpDto)
        {
            var result = await _registerLogic.RegisterMetodoHttpAsync(createMetodoHttpDto);
            return createMetodoHttpDto;
        }

    }
}
