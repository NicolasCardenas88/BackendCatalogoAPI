using BackendCatalogoAXA.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IGetData
    {
        Task <Servicio> FindServicioByIdAsync (int id); 
    }
}
