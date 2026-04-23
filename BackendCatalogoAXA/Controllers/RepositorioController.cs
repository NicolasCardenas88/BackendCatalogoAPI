using BackendCatalogoAXA.Model.Dto.DtoRepositorio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class RepositorioController(IRegisterLogic registerLogic, IRepositorioLogic repoLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IRepositorioLogic _repoLogic = repoLogic;

        [HttpPost("/repositorio/V1")]
        public async Task<CreateRepositorioDto> CreateRepositorioAsync (CreateRepositorioDto createRepositorioDto)
        {
            var result = await _registerLogic.RegisterRepositorioAsync(createRepositorioDto);
            return createRepositorioDto;
        }

        [HttpGet("/repositorio/V1")]
        public async Task<IActionResult> GetRepositorio()
        {
            var result = await _repoLogic.GetAllAsync();
            return Ok(result);
        }
    }
}
