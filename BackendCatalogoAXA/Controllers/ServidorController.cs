using BackendCatalogoAXA.Model.Dto.DtoServidor;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ServidorController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        [HttpPost("/createservidor/")]
        public async Task<CreateServidorDto> CreateServidor([FromBody] CreateServidorDto createServidorDto)
        {
            var result = await _registerLogic.RegisterServidorAsync(createServidorDto);
            return createServidorDto;
        }
    }
}
