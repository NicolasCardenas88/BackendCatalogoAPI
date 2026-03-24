using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoAmbiente
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
