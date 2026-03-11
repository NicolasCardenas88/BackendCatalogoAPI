using Microsoft.AspNetCore.Mvc;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
namespace BackendCatalogoAXA.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class ServiceController (IServiceLogic serviceLogic) : ControllerBase
    {
        private readonly IServiceLogic _serviceLogic = serviceLogic;


        [HttpGet("/findservicio/{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceLogic.FindServicioByIdAsync(id);
            return Ok(service);
        }
    }
}
