namespace BackendCatalogoAXA.Data.Context;

public partial class Aplicacion
{
    public int AplicacionId { get; set; }

    public string Codigo { get; set; } = null!;

    public string ActivoId { get; set; } = null!;

    public string NombreApp { get; set; } = null!;

    public string? DescripcionFuncional { get; set; }

    public int EstadoId { get; set; }

    public int? FrameworkId { get; set; }

    public string? Urltst { get; set; }

    public string? Urluat { get; set; }

    public string? Urlprod { get; set; }

    public int? UnidadNegocioId { get; set; }
    public virtual Activo? activo { get; set; }
    public virtual Estado Estado { get; set; } = null!;

    public virtual Framework? Framework { get; set; }

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();

    public virtual UnidadNegocio? UnidadNegocio { get; set; }
}
