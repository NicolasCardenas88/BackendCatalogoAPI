using BackendCatalogoAXA.Data.Dto.DtoApimanager;
using BackendCatalogoAXA.Data.Dto.DtoBalanceo;
using BackendCatalogoAXA.Data.Dto.DtoLog;
using BackendCatalogoAXA.Data.Dto.DtoServicioModulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoServicio
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
        public int ServicioId { get; internal set; }
    }
}
