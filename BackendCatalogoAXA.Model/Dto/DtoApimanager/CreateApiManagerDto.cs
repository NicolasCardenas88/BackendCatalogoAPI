namespace BackendCatalogoAXA.Model.Dto.DtoApimanager
{
    public class CreateApiManagerDto
    {
        private string? _Codigo;
        public int ServicioId { get; set; }
        private string? _Catalogo;
        private string? _NombreApi;
        private string? _Version;
        private string? _Recurso;
        public int MetodoHttpID { get; set; }
        private string? _Url;
        public int AmbienteId { get; set; }

        public string? Codigo
        {
            get => _Codigo;
            set => _Codigo = value.Trim();
        }

        public string? Catalogo
        {
            get => _Catalogo;
            set => _Catalogo = value.Trim();
        }
        public string? NombreApi
        {
            get => _NombreApi;
            set => _NombreApi = value.Trim();
        }
        public string? Version
        {
            get => _Version;
            set => _Version = value.Trim();
        }
        public string? Recurso
        {
            get => _Recurso;
            set => _Recurso = value.Trim();
        }
        public string? Url
        {
            get => _Url;
            set => _Url = value.Trim();
        }
    }
}
