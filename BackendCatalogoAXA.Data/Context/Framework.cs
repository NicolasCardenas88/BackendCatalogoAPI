namespace BackendCatalogoAXA.Data.Context;

public partial class Framework
{
    public int FrameworkId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Aplicacion> Aplicacions { get; set; } = new List<Aplicacion>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
