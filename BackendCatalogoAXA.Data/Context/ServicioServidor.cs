
namespace BackendCatalogoAXA.Data.Context;

public partial class ServicioServidor
{
    public int ServicioServidorId { get; set; }

    public int ServidorId { get; set; }

    public int ServicioId { get; set; }

    public int? Puerto { get; set; }

    public int? EstadoId { get; set; }

    public int? AmbienteId { get; set; }

    public virtual Ambiente? Ambiente { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Servidor Servidor { get; set; } = null!;
}
