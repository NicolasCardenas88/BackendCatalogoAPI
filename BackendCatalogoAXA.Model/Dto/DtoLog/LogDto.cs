namespace BackendCatalogoAXA.Model.Dto.DtoLog
{
    public class LogDto
    {
        private string? _codigo;
        public string? Codigo
        {
            get => _codigo;
            set => _codigo = value?.Trim();
        }

        private string? _rutaLog;
        public string? RutaLog
        {
            get => _rutaLog;
            set => _rutaLog = value?.Trim();
        }
    }
}
