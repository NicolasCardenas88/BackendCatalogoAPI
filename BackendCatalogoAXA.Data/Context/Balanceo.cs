using System;
using System.Collections.Generic;

namespace BackendCatalogoAXA.Data.Context;

public partial class Balanceo
{
    public int BalanceoId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int AmbienteId { get; set; }

    public virtual Ambiente Ambiente { get; set; } = null!;

    public virtual ICollection<BalanceoServicio> BalanceoServicios { get; set; } = new List<BalanceoServicio>();
}
