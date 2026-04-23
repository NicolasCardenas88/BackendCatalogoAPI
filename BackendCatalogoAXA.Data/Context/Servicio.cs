namespace BackendCatalogoAXA.Data.Context;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int TipoServicioId { get; set; }

    public int? ProtocoloId { get; set; }

    public int? FrameworkId { get; set; }

    public int EstadoId { get; set; }

    public string? Descripcion { get; set; }

    public string? Propietario { get; set; }

    public int? UnidadNegocioId { get; set; }

    public virtual ICollection<Apimanager> Apimanagers { get; set; } = new List<Apimanager>();

    public virtual ICollection<BalanceoServicio> BalanceoServicios { get; set; } = new List<BalanceoServicio>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual Framework? Framework { get; set; }

    public virtual Protocolo? Protocolo { get; set; }

    public virtual ICollection<RepositorioColeccion> RepositorioColeccions { get; set; } = new List<RepositorioColeccion>();

    public virtual ICollection<RepositorioServicio> RepositorioServicios { get; set; } = new List<RepositorioServicio>();

    public virtual ICollection<ServicioLog> ServicioLogs { get; set; } = new List<ServicioLog>();

    public virtual ICollection<ServicioModulo> ServicioModulos { get; set; } = new List<ServicioModulo>();

    public virtual ICollection<ServicioServidor> ServicioServidors { get; set; } = new List<ServicioServidor>();

    public virtual TipoServicio TipoServicio { get; set; } = null!;

    public virtual UnidadNegocio? UnidadNegocio { get; set; }
}
