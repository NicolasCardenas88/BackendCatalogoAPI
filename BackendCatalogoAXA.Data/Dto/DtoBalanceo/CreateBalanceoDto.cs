using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoBalanceo
{
    public class CreateBalanceoDto
    {
        public string? Codigo { get; set; }
        public string? URL { get; set; }
        public int? AmbienteID { get; set; }
        public int? ServicioID { get; set; }   
        public string? URLCompleta { get; set; }
    }
}
