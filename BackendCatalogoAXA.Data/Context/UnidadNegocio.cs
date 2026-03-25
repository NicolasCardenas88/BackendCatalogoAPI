namespace BackendCatalogoAXA.Data.Context;

public partial class UnidadNegocio
{
    public int UnidadNegocioId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Aplicacion> Aplicacions { get; set; } = new List<Aplicacion>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    public virtual ICollection<Servidor> Servidors { get; set; } = new List<Servidor>();
}
