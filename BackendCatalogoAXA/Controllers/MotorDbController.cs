using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoMotorDB;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    
    [ApiController]
    [Route("api/catalogo")]
    public class MotorDbController (IRegisterLogic registerLogic, IMotorDBLogic motorDBLogic) : ControllerBase 
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IMotorDBLogic _motorDBLogic = motorDBLogic;

        [HttpPost ("/motorDb/V1")]
        public async Task<CreateMotorDbDto> CreateMotorDb([FromBody] CreateMotorDbDto dto)
        {
            var response = await _registerLogic.RegisterMotorDbAsync(dto);
            return dto;
        }

        [HttpGet("/motorDb/V1")]
        public async Task<IActionResult> GetMotorDb()
        {
            var result = await _motorDBLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
