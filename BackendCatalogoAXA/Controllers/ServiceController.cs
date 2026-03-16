using BackendCatalogoAXA.Data.Dto.DtoFiltroServicio;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ServiceController (IServiceLogic serviceLogic) : ControllerBase
    {
        private readonly IServiceLogic _serviceLogic = serviceLogic;


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
    }
}
