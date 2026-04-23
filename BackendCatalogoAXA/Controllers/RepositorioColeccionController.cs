using BackendCatalogoAXA.Model.Dto.DtoRepositorioColeccion;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class RepositorioColeccionController(IRegisterLogic registerLogic, IRepositorioColeccionLogic repoColeccionLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;
        private readonly IRepositorioColeccionLogic _repoColeccionLogic = repoColeccionLogic;

        [HttpPost("/repositorioColeccion/V1")]
        public async Task<CreateRepositoriosColeccionDto> CreateRepositorioColeccion([FromBody] CreateRepositoriosColeccionDto createRepositoriosColeccionDto)
        {
            var result = await _registerLogic.RegisterRepositorioColeccionAsync(createRepositoriosColeccionDto);
            return createRepositoriosColeccionDto;
        }

        [HttpGet("/repositorioColeccion/V1")]
        public async Task<IActionResult> GetRepoColeccion()
        {
            var resultado = await _repoColeccionLogic.GetAllAsync();
            return Ok(resultado);
        }
    }
}
