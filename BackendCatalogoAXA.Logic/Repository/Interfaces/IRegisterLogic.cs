using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IRegisterLogic
    {
        Task<bool> RegisterLogicAsync(CrearServicioDto crearServicioDto);
    }
}
