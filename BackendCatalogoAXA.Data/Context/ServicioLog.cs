using System;
using System.Collections.Generic;

namespace BackendCatalogoAXA.Data.Context;

public partial class ServicioLog
{
    public int ServicioLogId { get; set; }

    public int ServicioId { get; set; }

    public int LogId { get; set; }

    public virtual Log Log { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
