using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoApimanager
{
    public class CreateApiManagerDto
    {
        public string Codigo { get; set; }
        public int ServicioId { get; set; }
        public string Catalogo { get; set; }
        public string NombreApi { get; set; }
        public string Version { get; set; }
        public string Recurso { get; set; }
        public int MetodoHttp {  get; set; }
        public string Url { get; set; }
        public int AmbienteId { get; set; }

    }
}
