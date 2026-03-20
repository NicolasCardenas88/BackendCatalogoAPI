using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoLog
{
    public class CreateLogDto
    {
        private string? _Codigo;
        private string? _RutaLog;
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


    }
}
