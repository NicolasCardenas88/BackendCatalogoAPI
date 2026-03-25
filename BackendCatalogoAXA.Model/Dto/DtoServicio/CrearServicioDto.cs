namespace BackendCatalogoAXA.Model.Dto.CrearServicioDtoServicio
{
    public class CrearServicioDto
    {
        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public int TipoServicioId { get; set; }

        public int? ProtocoloId { get; set; }

        public int? FrameworkId { get; set; }

        public int EstadoId { get; set; }

        public string? Descripcion { get; set; }

        public string? Propietario { get; set; }

        public int? UnidadNegocioId { get; set; }
    }
}
