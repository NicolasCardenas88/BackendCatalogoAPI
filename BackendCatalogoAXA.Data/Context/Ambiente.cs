

namespace BackendCatalogoAXA.Data.Context;

public partial class Ambiente
{
    public int AmbienteId { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Apimanager> Apimanagers { get; set; } = new List<Apimanager>();

    public virtual ICollection<Balanceo> Balanceos { get; set; } = new List<Balanceo>();

    public virtual ICollection<ServicioServidor> ServicioServidors { get; set; } = new List<ServicioServidor>();

    public virtual ICollection<Servidor> Servidors { get; set; } = new List<Servidor>();
}
