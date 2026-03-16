using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoModulo
{
    public class CreateModuloDto
    {
        public string Codigo { get; set; }
        public int AplicacionId { get; set; }
        public string Nombre { get; set; }
    }
}
