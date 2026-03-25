namespace BackendCatalogoAXA.Model.Dto.DtoTipoServicio
{
    public class CreateTipoServicioDto
    {
        private string? _Nombre;

        public string? Nombre
        {
            get => _Nombre;
            set => _Nombre = value.Trim();
        }
    }
}
