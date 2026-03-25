using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;

namespace BackendCatalogoAXA.Model.Dto.DtoApimanager
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
