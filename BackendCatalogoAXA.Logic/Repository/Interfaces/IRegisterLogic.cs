using BackendCatalogoAXA.Model.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Model.Dto.DtoActivo;
using BackendCatalogoAXA.Model.Dto.DtoBalanceo;
using BackendCatalogoAXA.Model.Dto.DtoCategoriaServidor;
using BackendCatalogoAXA.Model.Dto.DtoLog;
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
        Task<bool> RegisterRepositorioColeccionAsync(CreateRepositoriosColeccionDto createRepositoriosColeccionDto);
        Task<bool> RegisterTipoServicioAsync(CreateTipoServicioDto createTipoServicioDto);
        Task<bool> RegisterUnidadNegocioAsync(CreateUnidadNegocioDto createUnidadNegocioDto);
        Task<bool> RegisterProtocoloAsync(CreateProtocoloDto createProtocoloDto);
        Task<bool> RegisterRepositorioAsync(CreateRepositorioDto createRepositorioDto);
        Task<bool> RegisterBalanceoAsync(CreateBalanceoDto createBalanceoDto);
        Task<bool> RegisterServidorAsync(CreateServidorDto createServidorDto);
        Task<bool> RegisterSistemaOperativoAsync(CreateSistemaOperativoDto createSistemaOperativoDto);
        Task<bool> RegisterMotorDbAsync(CreateMotorDbDto createMotorDbDto);
        Task<bool> RegisterCategoriaServidorAsync(CreateCategoriaServidorDto createCategoriaServidorDto);
        Task<bool> RegisterActivoAsync(CreateActivoDto createActivoDto);
        Task<bool> RegisterModuloAsync(CreateModuloDto createModuloDto);


    }
}
