

using BackendCatalogoAXA.Model.Dto.DtoAmbiente;

namespace BackendCatalogoAXA.Model.Dto.DtoBalanceo
{
    public class BalanceoServicioDto
    {
        public string? CodigoBalanceo { get; set; }
        public string? UrlBase { get; set; }
        public string? UrlCompleta { get; set; }
        public AmbienteDto? Ambiente { get; set; }

    }
}
