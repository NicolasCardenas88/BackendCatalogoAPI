using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IRegisterData
    {
        // 
        Task<bool> RegisterLogicAsync<T>(T crearServicioDto);

    }
}
