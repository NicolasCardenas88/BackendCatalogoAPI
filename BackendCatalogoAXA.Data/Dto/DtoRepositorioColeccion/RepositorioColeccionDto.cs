using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoRepositorioColeccion
{
    public class RepositorioColeccionDto
    {
        public string Codigo { get; set; }
        public int ServicioId { get; set; }
        public string UrlColeccion { get; set; }
        public string UrlColeccionAzure { get; set; }
    }
}
