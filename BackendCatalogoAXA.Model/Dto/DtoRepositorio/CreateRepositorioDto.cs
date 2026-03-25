

namespace BackendCatalogoAXA.Model.Dto.DtoRepositorio
{
    public class CreateRepositorioDto
    {
        private string? _Codigo;
        private string? _UrlRepositorio;
        private string? _UrlLibrerias;

        public string? Codigo
        {
            get => _Codigo;
            set => _Codigo = value.Trim();
        }
        public string? UrlRepositorio
        {
            get => _UrlRepositorio;
            set => _UrlRepositorio = value.Trim();
        }
        public string? UrlLibrerias
        {
            get => _UrlLibrerias;
            set => _UrlLibrerias = value.Trim();
        }
    }
}
