
namespace BackendCatalogoAXA.Data.Context;

public partial class BalanceoServicio
{
    public int BalanceoServicioId { get; set; }

    public int BalanceoId { get; set; }

    public int ServicioId { get; set; }

    public string? Urlcompleta { get; set; }

    public virtual Balanceo Balanceo { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
