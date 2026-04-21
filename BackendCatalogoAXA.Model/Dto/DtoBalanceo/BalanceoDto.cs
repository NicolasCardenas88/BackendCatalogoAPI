

using BackendCatalogoAXA.Model.Dto.DtoAmbiente;

namespace BackendCatalogoAXA.Model.Dto.DtoBalanceo
{
    public class BalanceoDto
    {
        private string? _codigo;
        private string? _url;
        public AmbienteDto? Ambiente { get; set; } = new AmbienteDto();

        public string Codigo
        {
            get => _codigo ?? string.Empty;
            set => _codigo = value.Trim();
        }
        public string Url
        {
            get => _url ?? string.Empty;
            set => _url = value.Trim();
        }
    }
}
