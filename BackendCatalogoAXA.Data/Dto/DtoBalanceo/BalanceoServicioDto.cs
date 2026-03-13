using BackendCatalogoAXA.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoBalanceo
{
    public class BalanceoServicioDto
    {
        public string Codigo { get; set; }
        public string Url { get; set; }
        public List<Ambiente> ambientes { get; set; } = new List<Ambiente>();

    }
}
