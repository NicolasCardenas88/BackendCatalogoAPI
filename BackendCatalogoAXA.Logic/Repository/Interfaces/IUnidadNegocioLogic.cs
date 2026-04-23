using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IUnidadNegocioLogic
    {
        Task<List<UnidadNegocioDto>> GetAllAsync();
    }
}
