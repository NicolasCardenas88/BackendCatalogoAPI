using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoTipoServicio
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
