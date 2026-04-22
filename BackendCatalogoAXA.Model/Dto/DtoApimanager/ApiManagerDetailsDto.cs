using BackendCatalogoAXA.Model.Dto.DtoAmbiente;


namespace BackendCatalogoAXA.Model.Dto.DtoApimanager
{
    public class ApiManagerDetailsDto
    {
        public string? Codigo { get; set; }
        public string? Catalogo { get; set; }
        public string? NombreApi { get; set; }
        public string? Version { get; set; }
        public string? Recurso { get; set; }
        public string? MetodoHttp { get; set; }
        public string? Url { get; set; }
        public AmbienteDto? Ambiente { get; set; }
    }
}
