namespace BackendCatalogoAXA.Data.Context;

public partial class Servidor
{
    public int ServidorId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int? CategoriaServidorId { get; set; }

    public int? EntornoId { get; set; }

    public int? EstadoId { get; set; }

    public string? Descripcion { get; set; }

    public string? UsuarioResponsable { get; set; }

    public DateOnly? FechaResponsabilidad { get; set; }

    public DateTime? UltimaModificacion { get; set; }

    public int? UnidadNegocioId { get; set; }

    public string? Ip { get; set; }

    public decimal? DiscoHddGb { get; set; }

    public decimal? MemoriaGb { get; set; }

    public decimal? MemoriaActualGb { get; set; }

    public decimal? EspacioDiscoGb { get; set; }

    public decimal? EspacioActualDiscoGb { get; set; }

    public int? SistemaOperativoId { get; set; }

    public int? CantidadScores { get; set; }

    public bool? TieneDrp { get; set; }

    public DateOnly? FechaApagado { get; set; }

    public int? AmbienteId { get; set; }

    public string? Dominio { get; set; }

    public string? AplicacionNombre { get; set; }

    public int? Sockets { get; set; }

    public string? Adapter { get; set; }

    public int? MotorBdid { get; set; }

    public string? Observacion { get; set; }

    public DateOnly? FechaDecomision { get; set; }

    public bool? ApagadoPorAmbiente { get; set; }

    public bool? MonitoriadoOrion { get; set; }

    public string? AmbientesQa { get; set; }

    public string? GruposRed { get; set; }

    public string? Agrupacion { get; set; }

    public virtual Ambiente? Ambiente { get; set; }

    public virtual CategoriaServidor? CategoriaServidor { get; set; }

    public virtual Entorno? Entorno { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual MotorBd? MotorBd { get; set; }

    public virtual ICollection<ServicioServidor> ServicioServidors { get; set; } = new List<ServicioServidor>();

    public virtual SistemaOperativo? SistemaOperativo { get; set; }

    public virtual UnidadNegocio? UnidadNegocio { get; set; }
}
