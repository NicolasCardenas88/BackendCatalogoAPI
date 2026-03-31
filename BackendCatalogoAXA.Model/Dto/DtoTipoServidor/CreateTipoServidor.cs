namespace BackendCatalogoAXA.Model.Dto.DtoTipoServidor
{
    public class CreateTipoServidor
    {
        private string? _Nombre;

        public string? Nombre
        {
            get => _Nombre;
            set => _Nombre = value.Trim();
        }
    }
}
