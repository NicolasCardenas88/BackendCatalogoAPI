using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoProtocolo
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
