using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoFiltroServicio
{
    public class FiltroServicioDto
    {
        public string? Url { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public int? TipoServicioId { get; set; }
        public int? EstadoId { get; set; }
    }
}
