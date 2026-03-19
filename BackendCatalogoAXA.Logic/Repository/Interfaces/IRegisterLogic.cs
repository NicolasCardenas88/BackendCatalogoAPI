using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoApimanager;
using BackendCatalogoAXA.Data.Dto.DtoFramework;
using BackendCatalogoAXA.Data.Dto.DtoLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IRegisterLogic
    {
        Task<bool> RegisterServiceAsync(CrearServicioDto crearServicioDto);
        Task<bool> RegisterFrameworkAsync(CreateFrameworkDto createFrameworkDto);
        Task<bool> RegisterApiManager (CreateApiManagerDto createApiManagerDto);
      Task<bool> RegisterLogAsync<TCreateDto, TEntidad, TRelacion>(
    TCreateDto createDto,
    int idPadre,
    Func<int, int, TRelacion> crearRelacion)
    where TEntidad : class
    where TRelacion : class;

    }
}
