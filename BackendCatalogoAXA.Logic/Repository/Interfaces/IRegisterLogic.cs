using BackendCatalogoAXA.Model.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Model.Dto.DtoActivo;
using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using BackendCatalogoAXA.Model.Dto.DtoBalanceo;
using BackendCatalogoAXA.Model.Dto.DtoCategoriaServidor;
using BackendCatalogoAXA.Model.Dto.DtoEntorno;
using BackendCatalogoAXA.Model.Dto.DtoEstado;
using BackendCatalogoAXA.Model.Dto.DtoFramework;
using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Model.Dto.DtoMotorDB;
using BackendCatalogoAXA.Model.Dto.DtoProtocolo;
using BackendCatalogoAXA.Model.Dto.DtoRepositorio;
using BackendCatalogoAXA.Model.Dto.DtoRepositorioColeccion;
using BackendCatalogoAXA.Model.Dto.DtoServidor;
using BackendCatalogoAXA.Model.Dto.DtoSistemaOperativo;
using BackendCatalogoAXA.Model.Dto.DtoTipoServicio;
using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;


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
        Task<bool> RegisterServidorAsync(CreateServidorDto createServidorDto);
        Task<bool> RegisterSistemaOperativoAsync(CreateSistemaOperativoDto createSistemaOperativoDto);
        Task<bool> RegisterMotorDbAsync(CreateMotorDbDto createMotorDbDto);
        Task<bool> RegisterCategoriaServidorAsync(CreateCategoriaServidorDto createCategoriaServidorDto);
        Task<bool> RegisterEntornoAsync(CreateEntornoDto createEntornoDto);
        Task<bool> RegisterActivoAsync(CreateActivoDto createActivoDto);

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
