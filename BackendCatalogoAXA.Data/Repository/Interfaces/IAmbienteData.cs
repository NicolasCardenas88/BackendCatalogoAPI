using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IAmbienteData
    {
        Task<List<AmbienteDto>> getAllAsync();
    }
}
