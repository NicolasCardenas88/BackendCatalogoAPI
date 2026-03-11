using System;
using System.Collections.Generic;

namespace BackendCatalogoAXA.Data.Context;

public partial class TipoServicio
{
    public int TipoServicioId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
