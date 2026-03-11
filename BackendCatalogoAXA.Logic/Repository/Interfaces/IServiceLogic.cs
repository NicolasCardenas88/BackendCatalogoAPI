using BackendCatalogoAXA.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IServiceLogic 
    {
        Task<Servicio> FindServicioByIdAsync(int id); 
    }
}
