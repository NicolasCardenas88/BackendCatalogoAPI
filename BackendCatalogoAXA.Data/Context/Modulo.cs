namespace BackendCatalogoAXA.Data.Context;

public partial class Modulo
{
    public int ModuloId { get; set; }

    public string Codigo { get; set; } = null!;

    public int AplicacionId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual Aplicacion Aplicacion { get; set; } = null!;

    public virtual ICollection<ServicioModulo> ServicioModulos { get; set; } = new List<ServicioModulo>();
}
