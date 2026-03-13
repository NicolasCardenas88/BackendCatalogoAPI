using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.DtoServicio;
using BackendCatalogoAXA.Data.Mapper.MapperService;
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


        public async Task<DetailsServicioDto> FindServicioByIdAsync(int id)
        {
            return await _getData.FindServicioByIdAsync(id);
           
        }
        public async Task<List<Servicio>> FindAllServicios()
        {
            var servicio = await _getData.FindAllServicios();
            return servicio;
        }

    }
}
