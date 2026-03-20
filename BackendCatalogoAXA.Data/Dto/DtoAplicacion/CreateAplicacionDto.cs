namespace BackendCatalogoAXA.Data.Dto.DtoAplicacion
{
    public class CreateAplicacionDto
    {
        private string? _Codigo;
        private string? _ActivoId;
        private string? _NombreApp;
        private string? _DescripcionFuncional;
        private int? _EstadoId;
        private int? _FrameworkId;
        private string? _UrlTst;
        private string? _UrlUat;
        private string? _UrlPrd;
        private int? _UnidadNegocioId;
       
        public string? Codigo { get => _Codigo; set => _Codigo = value?.Trim(); }
        public string? ActivoId { get => _ActivoId; set => _ActivoId = value?.Trim(); }
        public string? NombreApp { get => _NombreApp; set => _NombreApp = value?.Trim(); }
        public string? DescripcionFuncional { get => _DescripcionFuncional; set => _DescripcionFuncional = value?.Trim(); }
        public int? EstadoId { get => _EstadoId; set => _EstadoId = value; }
        public int? FrameworkId { get => _FrameworkId; set => _FrameworkId = value; }
        public string? UrlTst { get => _UrlTst; set => _UrlTst = value?.Trim(); }
        public string? UrlUat { get => _UrlUat; set => _UrlUat = value?.Trim(); }
        public string? UrlPrd { get => _UrlPrd; set => _UrlPrd = value?.Trim(); }
        public int? UnidadNegocioId { get => _UnidadNegocioId; set => _UnidadNegocioId = value; }

    }
}
