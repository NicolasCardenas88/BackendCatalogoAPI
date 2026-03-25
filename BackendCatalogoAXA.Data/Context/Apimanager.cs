
namespace BackendCatalogoAXA.Data.Context;

public partial class Apimanager
{
    public int ApimanagerId { get; set; }

    public string Codigo { get; set; } = null!;

    public int ServicioId { get; set; }

    public string? Catalogo { get; set; }

    public string NombreApi { get; set; } = null!;

    public string Version { get; set; } = null!;

    public string Recurso { get; set; } = null!;

    public int MetodoHttpid { get; set; }

    public string Url { get; set; } = null!;

    public int AmbienteId { get; set; }

    public virtual Ambiente Ambiente { get; set; } = null!;

    public virtual MetodoHttp MetodoHttp { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
