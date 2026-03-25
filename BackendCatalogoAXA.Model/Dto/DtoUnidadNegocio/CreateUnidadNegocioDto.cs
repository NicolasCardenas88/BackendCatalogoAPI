namespace BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio
{
    public class CreateUnidadNegocioDto
    {
        private string? _Nombre {  get; set; }
        public string? Nombre
        {
            get => _Nombre;
            set => _Nombre = value.Trim();
        }
    }
}
