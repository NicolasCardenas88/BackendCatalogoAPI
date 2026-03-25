namespace BackendCatalogoAXA.Data.Context;

public partial class Repositorio
{
    public int RepositorioId { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Urlrepositorio { get; set; }

    public string? Urllibrerias { get; set; }

    public virtual ICollection<RepositorioServicio> RepositorioServicios { get; set; } = new List<RepositorioServicio>();
}
