namespace BackendCatalogoAXA.Model.Dto.DtoServicio
{
    public class UpdateServicioDto
    {
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
