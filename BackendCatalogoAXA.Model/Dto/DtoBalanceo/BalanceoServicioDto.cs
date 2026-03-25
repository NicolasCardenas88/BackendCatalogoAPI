

using BackendCatalogoAXA.Model.Dto.DtoAmbiente;

namespace BackendCatalogoAXA.Model.Dto.DtoBalanceo
{
    public class BalanceoServicioDto
    {
        public string Codigo { get; set; }
        public string Url { get; set; }
        public List<AmbienteDto> ambientes { get; set; } = new List<AmbienteDto>();

    }
}
