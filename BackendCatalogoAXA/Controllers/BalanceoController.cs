using BackendCatalogoAXA.Model.Dto.DtoBalanceo;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class BalanceoController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        [HttpPost("/createbalanceo/")]
        public async Task<CreateBalanceoDto> CreateBalanceoAsync([FromBody] CreateBalanceoDto createBalanceoDto )
        {
            var result = await _registerLogic.RegisterBalanceoAsync(createBalanceoDto);
            return createBalanceoDto;
        }
    }
}
