namespace BackendCatalogoAXA.Model.Dto.DtoProtocolo
{
    public class CreateProtocoloDto
    {
        private string? _Nombre;

        public string? Nombre
        {
            get => _Nombre;
            set => _Nombre = value.Trim();
        }
    }
}
