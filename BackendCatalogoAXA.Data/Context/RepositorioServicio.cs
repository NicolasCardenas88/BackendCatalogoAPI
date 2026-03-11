using System;
using System.Collections.Generic;

namespace BackendCatalogoAXA.Data.Context;

public partial class RepositorioServicio
{
    public int RepositorioServicioId { get; set; }

    public int RepositorioId { get; set; }

    public int ServicioId { get; set; }

    public virtual Repositorio Repositorio { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
