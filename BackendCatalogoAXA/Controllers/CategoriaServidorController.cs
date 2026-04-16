using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoCategoriaServidor;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    
    [ApiController]
    [Route("api/catalogo")]
    public class CategoriaServidorController (IRegisterLogic registerLogic): ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/categoriaServidor/")]
        public async Task<CreateCategoriaServidorDto> CreateCategoriaServidor([FromBody] CreateCategoriaServidorDto dto)
        {
            var result = await _registerLogic.RegisterCategoriaServidorAsync(dto);
            return dto;
        }
    }
}
