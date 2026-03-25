

namespace BackendCatalogoAXA.Model.Dto.DtoAmbiente
{
    public class CreateAmbienteDto
    {
        private string? _Codigo;
        private string? _Descripcion;

        public string? Codigo
        {
            get => _Codigo;
            set => _Codigo = value.Trim();
        }
        public string? Descripcion
        {
            get => _Descripcion;
            set => _Descripcion = value.Trim();
        }
    }
}
