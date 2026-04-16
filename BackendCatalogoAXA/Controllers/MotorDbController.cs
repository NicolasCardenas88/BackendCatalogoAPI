using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoMotorDB;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    
    [ApiController]
    [Route("api/catalogo")]
    public class MotorDbController (IRegisterLogic registerLogic) : ControllerBase 
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        [HttpPost ("/motorDb")]
        public async Task<CreateMotorDbDto> CreateMotorDb([FromBody] CreateMotorDbDto dto)
        {
            var response = await _registerLogic.RegisterMotorDbAsync(dto);
            return dto;
        }
    }
}
