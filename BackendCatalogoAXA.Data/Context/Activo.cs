
namespace BackendCatalogoAXA.Models;

public partial class Activo
{
    public int ActivoId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public bool? TieneMfa { get; set; }
}
