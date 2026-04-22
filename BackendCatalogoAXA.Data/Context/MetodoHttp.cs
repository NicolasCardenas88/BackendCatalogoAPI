namespace BackendCatalogoAXA.Data.Context;

public partial class MetodoHttp
{
    public int MetodoHttpid { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Apimanager> Apimanagers { get; set; } = new List<Apimanager>();
}
