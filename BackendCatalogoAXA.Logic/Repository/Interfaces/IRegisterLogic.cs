using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoAmbiente;
using BackendCatalogoAXA.Data.Dto.DtoApimanager;
using BackendCatalogoAXA.Data.Dto.DtoAplicacion;
using BackendCatalogoAXA.Data.Dto.DtoBalanceo;
using BackendCatalogoAXA.Data.Dto.DtoEstado;
using BackendCatalogoAXA.Data.Dto.DtoFramework;
using BackendCatalogoAXA.Data.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Data.Dto.DtoProtocolo;
using BackendCatalogoAXA.Data.Dto.DtoRepositorio;
using BackendCatalogoAXA.Data.Dto.DtoRepositorioColeccion;
using BackendCatalogoAXA.Data.Dto.DtoTipoServicio;
using BackendCatalogoAXA.Data.Dto.DtoUnidadNegocio;


namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IRegisterLogic
    {
        Task<bool> RegisterServiceAsync(CrearServicioDto crearServicioDto);
        Task<bool> RegisterFrameworkAsync(CreateFrameworkDto createFrameworkDto);
        Task<bool> RegisterApiManagerAsync(CreateApiManagerDto createApiManagerDto);
        Task<bool> RegisterMetodoHttpAsync(CreateMetodoHttpDto createMetodoHttpDto);
        Task<bool> RegisterRepositorioColeccionAsync(CreateRepositoriosColeccionDto createRepositoriosColeccionDto);
        Task<bool> RegisterAplicacionAsync(CreateAplicacionDto createAplicacionDto);
        Task<bool> RegisterTipoServicioAsync(CreateTipoServicioDto createTipoServicioDto);
        Task<bool> RegisterEstadoAsync(CreateEstadoDto createEstadoDto);
        Task<bool> RegisterUnidadNegocioAsync(CreateUnidadNegocioDto createUnidadNegocioDto);
        Task<bool> RegisterProtocoloAsync(CreateProtocoloDto createProtocoloDto);
        Task<bool> RegisterAmbienteAsync(CreateAmbienteDto createAmbienteDto);
        Task<bool> RegisterRepositorioAsync(CreateRepositorioDto createRepositorioDto);
        Task<bool> RegisterBalanceoAsync(CreateBalanceoDto createBalanceoDto);

        Task<bool> RegisterLogAsync<TCreateDto, TEntidad, TRelacion>(
        TCreateDto createDto,
        int idPadre,
        Func<int, int, TRelacion> crearRelacion)
        where TEntidad : class
        where TRelacion : class;
        Task<bool> RegisterModuloAsync<TCreateDto, TEntidad, TRelacion>(
        TCreateDto createDto,
        int idPadre,
        Func<int, int, TRelacion> crearRelacion)
        where TEntidad : class
        where TRelacion : class;
    }
}
