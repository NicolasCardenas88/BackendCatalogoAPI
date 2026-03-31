namespace BackendCatalogoAXA.Model.Dto.DtoActivo
{
    public class CreateActivoDto
    {
        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public bool? TieneMfa { get; set; }
    }
}
