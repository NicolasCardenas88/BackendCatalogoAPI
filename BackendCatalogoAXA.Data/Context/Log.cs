using System;
using System.Collections.Generic;

namespace BackendCatalogoAXA.Data.Context;

public partial class Log
{
    public int LogId { get; set; }

    public string Codigo { get; set; } = null!;

    public string RutaLog { get; set; } = null!;

    public virtual ICollection<ServicioLog> ServicioLogs { get; set; } = new List<ServicioLog>();
}
