using BackendCatalogoAXA.Data.Dto.DtoRepositorio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class RepositorioController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost("/createrepositorio/")]
        public async Task<CreateRepositorioDto> CreateRepositorioAsync (CreateRepositorioDto createRepositorioDto)
        {
            var result = await _registerLogic.RegisterRepositorioAsync(createRepositorioDto);
            return createRepositorioDto;
        }
    }
}
