using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ServiceLogic(IGetData getData) : IServiceLogic
    {
        private readonly IGetData _getData = getData;

        public async Task<Servicio> FindServicioByIdAsync(int id)
        {
            var servicio = await _getData.FindServicioByIdAsync(id);
            return servicio;
        }
    }
}
