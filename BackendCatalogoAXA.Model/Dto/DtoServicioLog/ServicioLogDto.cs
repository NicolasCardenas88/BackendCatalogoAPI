namespace BackendCatalogoAXA.Model.Dto.DtoLog
{
    public class ServicioLogDto
    {
        private string? _CodigoLog;
        private string? _RutaLog;

        public string CodigoLog { get => _CodigoLog ?? string.Empty; set => _CodigoLog = value.Trim(); }
        public string RutaLog { get => _RutaLog ?? string.Empty; set => _RutaLog = value.Trim(); }
    }
}
