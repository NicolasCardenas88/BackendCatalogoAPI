using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IAmbienteLogic
    {
        Task<List<AmbienteDto>> getAllAsync();
    }
}
