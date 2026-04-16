namespace BackendCatalogoAXA.Model.Dto.DtoModulo
{
    public class CreateModuloDto
    {
        private string? _codigo;

        public int AplicacionId { get; set; }

        private string? _nombre;

        public int ServicioId { get; set; }

         public string? Nombre
        {
            get => _nombre;
            set => _nombre = value?.Trim();
        }

        public string? Codigo
        {
            get => _codigo;
            set => _codigo = value?.Trim();
        }
    }
}
