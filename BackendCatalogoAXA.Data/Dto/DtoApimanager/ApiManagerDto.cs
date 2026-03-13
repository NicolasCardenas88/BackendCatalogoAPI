using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.DtoAmbiente;
using BackendCatalogoAXA.Data.Dto.DtoMetodoHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoApimanager
{
    public class ApiManagerDto
    {
        public string Codigo { get; set; }
        public string Catalogo { get; set; }
        public string NombreApi { get; set; }
        public string Version { get; set; }
        public string Recurso { get; set; }
        public MetodoHttpDto? MetodoHttp { get; set; }
        public string Url { get; set; }
        public AmbienteDto? Ambiente { get; set; }
    }
}
