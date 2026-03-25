using BackendCatalogoAXA.Model.Dto.DtoEntorno;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class EntornoController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createentorno/")]
        public async Task<CreateEntornoDto> CreateEntornoAsync([FromBody] CreateEntornoDto createEntornoDto)
        {
            var result = await _registerLogic.RegisterEntornoAsync(createEntornoDto);
            return createEntornoDto;
        }
    }
}
