public class CreateModuloDto
{
    private string? _codigo;
    private string? _nombre;

    public string? Codigo { get => _codigo; set => _codigo = value?.Trim();}
    public string? Nombre { get => _nombre;set => _nombre = value?.Trim();}

    public int AplicacionId { get; set; }

    public int ServicioId { get; set; }
}