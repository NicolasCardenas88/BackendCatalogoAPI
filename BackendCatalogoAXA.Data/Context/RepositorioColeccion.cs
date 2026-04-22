using System;
using System.Collections.Generic;

namespace BackendCatalogoAXA.Data.Context;

public partial class RepositorioColeccion
{
    public int RepositorioColeccionId { get; set; }

    public string Codigo { get; set; } = null!;

    public int ServicioId { get; set; }

    public string? Urlcoleccion { get; set; }

    public string? UrlcoleccionAzure { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;
}
