using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IAplicacionData
    {
        Task<List<AplicacionDto>> getAllAsync();
    }
}
