using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using BackendCatalogoAXA.Model.Dto.DtoBalanceo;
using BackendCatalogoAXA.Model.Dto.DtoLog;
using BackendCatalogoAXA.Model.Dto.DtoServicioModulo;

namespace BackendCatalogoAXA.Model.Dto.DtoServicio
{
    public class DetailsServicioDto
    {
        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string? Propietario { get; set; }

        public List<ApiManagerDto> ApiManager { get; set; } = new();
        public List<BalanceoServicioDto> BalanceoServicios { get; set; } = new();
        public List<ServicioLogDto> ServicioLogs { get; set; } = new();
        public List<ServicioModuloDto> ServicioModulos { get; set; } = new();
    }
}
