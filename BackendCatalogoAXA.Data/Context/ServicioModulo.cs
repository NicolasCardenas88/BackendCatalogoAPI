using System;
using System.Collections.Generic;

namespace BackendCatalogoAXA.Data.Context;

public partial class ServicioModulo
{
    public int ServicioModuloId { get; set; }

    public int ServicioId { get; set; }

    public int ModuloId { get; set; }

    public virtual Modulo Modulo { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
