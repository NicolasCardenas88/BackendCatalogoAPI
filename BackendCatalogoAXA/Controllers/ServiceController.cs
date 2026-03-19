using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoFiltroServicio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ServiceController (IServiceLogic serviceLogic, 
        IRegisterLogic registerLogic) : ControllerBase
    {
        private readonly IServiceLogic _serviceLogic = serviceLogic;
        private readonly IRegisterLogic _registerLogic = registerLogic;

        [HttpGet("/findservicio/{id}")]
        public  async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceLogic.FindServicioByIdAsync(id);
            return Ok(service);

        }
        [HttpGet ("/findallservice")]
        public async Task <IActionResult> GetAllServices()
        {
            var service = await _serviceLogic.FindAllServicios();
            return Ok(service);
        }

        [HttpGet("/filterservice")]
        public async Task<IActionResult> GetServiciosByFiltro([FromQuery] FiltroServicioDto filtro)
        {
            var result = await _serviceLogic.FindServiciosByFiltroAsync(filtro);
            if (!result.Any())
                return NotFound("No se encontraron servicios");
            return Ok(result);
        }

        [HttpPost("/createservicio")]
        public async  Task<CrearServicioDto> CreateServicioAsync([FromBody] CrearServicioDto crearServicioDto)
        {
            var result = await _registerLogic.RegisterServiceAsync(crearServicioDto);
            return crearServicioDto;
        }

    }
}
