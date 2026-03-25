namespace BackendCatalogoAXA.Data.Context;

public partial class Entorno
{
    public int EntornoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Servidor> Servidors { get; set; } = new List<Servidor>();
}
