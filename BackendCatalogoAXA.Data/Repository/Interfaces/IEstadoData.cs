using BackendCatalogoAXA.Model.Dto.DtoEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IEstadoData
    {
        Task<List<EstadoDto>> GetAllAsync();
    }
}
