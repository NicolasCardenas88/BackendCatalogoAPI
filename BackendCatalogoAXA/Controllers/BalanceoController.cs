using BackendCatalogoAXA.Data.Dto.DtoBalanceo;
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
        public async Task<IActionResult> CreateBalanceoAsync([FromBody] CreateBalanceoDto createBalanceoDto )
        {
            var result = await _registerLogic.RegisterBalanceoAsync(createBalanceoDto);
            if (!result) return BadRequest(new { message = "No se pudo registrar el Balanceo" });

            return Ok(new { message = "Balanceo registrado correctamente" });
        }
    }
}
