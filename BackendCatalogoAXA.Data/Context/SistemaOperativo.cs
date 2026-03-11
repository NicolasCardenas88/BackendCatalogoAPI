using System;
using System.Collections.Generic;

namespace BackendCatalogoAXA.Data.Context;

public partial class SistemaOperativo
{
    public int SistemaOperativoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Servidor> Servidors { get; set; } = new List<Servidor>();
}
