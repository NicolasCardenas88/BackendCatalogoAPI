using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.DtoFiltroServicio;
using BackendCatalogoAXA.Data.Dto.DtoServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IGetData
    {
        Task <DetailsServicioDto> FindServicioByIdAsync (int id);
        Task<List<Servicio>> FindAllServicios();
        Task<IEnumerable<DetailsServicioDto>> FindServiciosByFiltroAsync(FiltroServicioDto filtro);
    }
}
