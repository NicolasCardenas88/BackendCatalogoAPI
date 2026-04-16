namespace BackendCatalogoAXA.Model.Dto.DtoActivo
{
    public class CreateActivoDto
    {

        private string _codigo = string.Empty;
        public string Codigo
        {
            get => _codigo;
            set => _codigo = value?.Trim() ?? string.Empty;
        }

        private string _nombre = string.Empty;
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value?.Trim() ?? string.Empty;
        }

        public bool? TieneMFA { get; set; }
    }
}
