using BackendCatalogoAXA.Model.Dto.DtoRepositorioColeccion;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class RepositorioColeccionController(IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpPost ("/createrepositoriocoleccion/") ]
        public async Task<CreateRepositoriosColeccionDto> CreateRepositorioColeccion([FromBody] CreateRepositoriosColeccionDto createRepositoriosColeccionDto)
        {
            var result = await _registerLogic.RegisterRepositorioColeccionAsync(createRepositoriosColeccionDto);
            return createRepositoriosColeccionDto;
        }
    }
}
