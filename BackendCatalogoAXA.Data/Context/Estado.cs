using System;
using System.Collections.Generic;

namespace BackendCatalogoAXA.Data.Context;

public partial class Estado
{
    public int EstadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Aplicacion> Aplicacions { get; set; } = new List<Aplicacion>();

    public virtual ICollection<ServicioServidor> ServicioServidors { get; set; } = new List<ServicioServidor>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    public virtual ICollection<Servidor> Servidors { get; set; } = new List<Servidor>();
}
