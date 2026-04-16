
namespace BackendCatalogoAXA.Model.Dto.DtoLog
{
    public class CreateLogDto
    {
        private string? _Codigo;
        private string? _RutaLog;
        private int? _ServicioId;
        public string? Codigo
        {
            get => _Codigo;
            set => _Codigo= value.Trim() ;
        }
        public string? RutaLog
        {
            get => _RutaLog;
            set => _RutaLog = value.Trim();
        }
        public int? ServicioId { get => _ServicioId; set => _ServicioId = value; }


    }
}
