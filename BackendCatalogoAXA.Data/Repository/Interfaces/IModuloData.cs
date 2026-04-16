using BackendCatalogoAXA.Model.Dto.Modulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IModuloData
    {
        Task<List<ModuloDto>> GetAllAsync();
    }
}
