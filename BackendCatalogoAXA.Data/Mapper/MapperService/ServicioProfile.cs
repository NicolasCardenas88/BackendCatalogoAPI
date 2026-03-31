using AutoMapper;
using BackendCatalogoAXA.Data.Context;
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
using BackendCatalogoAXA.Model.Dto.DtoLog;
using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Model.Dto.DtoModulo;
using BackendCatalogoAXA.Model.Dto.DtoMotorDB;
using BackendCatalogoAXA.Model.Dto.DtoProtocolo;
using BackendCatalogoAXA.Model.Dto.DtoRepositorio;
using BackendCatalogoAXA.Model.Dto.DtoRepositorioColeccion;
using BackendCatalogoAXA.Model.Dto.DtoRepositorioServicio;
using BackendCatalogoAXA.Model.Dto.DtoServicio;
using BackendCatalogoAXA.Model.Dto.DtoServicioModulo;
using BackendCatalogoAXA.Model.Dto.DtoServicioServidor;
using BackendCatalogoAXA.Model.Dto.DtoServidor;
using BackendCatalogoAXA.Model.Dto.DtoSistemaOperativo;
using BackendCatalogoAXA.Model.Dto.DtoTipoServicio;
using BackendCatalogoAXA.Model.Dto.DtoTipoServidor;
using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;
using BackendCatalogoAXA.Model.Dto.Modulo;


namespace BackendCatalogoAXA.Model.Mapper.MapperService
{
    public class ServicioProfile : Profile
    {
        public ServicioProfile() {

            CreateMap<Servicio, DetailsServicioDto>().ReverseMap();
            CreateMap<Servicio, CrearServicioDto>().ReverseMap();
            CreateMap<Apimanager, ApiManagerDto>().ReverseMap();
            CreateMap<Apimanager, CreateApiManagerDto>().ReverseMap();
            CreateMap<MetodoHttp, MetodoHttpDto>().ReverseMap();
            CreateMap<MetodoHttp, CreateMetodoHttpDto>().ReverseMap();
            CreateMap<Ambiente, AmbienteDto>().ReverseMap();
            CreateMap<Ambiente, CreateAmbienteDto>().ReverseMap();
            CreateMap<BalanceoServicio, BalanceoServicioDto>().ReverseMap();
            CreateMap<ServicioModulo, ServicioModuloDto>().ReverseMap();
            CreateMap<ServicioModulo, CreateServicioModuloDto>().ReverseMap();
            CreateMap<Modulo, ModuloDto>().ReverseMap();
            CreateMap<Modulo, CreateModuloDto>().ReverseMap();
            CreateMap<ServicioLog, ServicioLogDto>().ReverseMap();
            CreateMap<ServicioLog, CrearServicioDto>().ReverseMap();
            CreateMap<Log, LogDto>().ReverseMap();
            CreateMap<Log, CreateLogDto>().ReverseMap();
            CreateMap<Framework, CreateFrameworkDto>().ReverseMap();
            CreateMap<Aplicacion, CreateAplicacionDto>().ReverseMap();
            CreateMap<RepositorioColeccion, CreateRepositoriosColeccionDto>().ReverseMap();
            CreateMap<TipoServicio, CreateTipoServicioDto>().ReverseMap();
            CreateMap<Estado, CreateEstadoDto>().ReverseMap();
            CreateMap<UnidadNegocio, CreateUnidadNegocioDto>().ReverseMap();
            CreateMap<Protocolo, CreateProtocoloDto>().ReverseMap();
            CreateMap<Repositorio, CreateRepositorioDto>().ReverseMap();
            CreateMap<Servidor, CreateServidorDto>().ReverseMap();
            CreateMap<SistemaOperativo, CreateSistemaOperativoDto>().ReverseMap();
            CreateMap<MotorBd, CreateMotorDbDto>().ReverseMap();
            CreateMap<CategoriaServidor, CreateCategoriaServidorDto>().ReverseMap();
            CreateMap<Entorno, CreateEntornoDto>().ReverseMap();
            CreateMap<ServicioServidor, CreateServicioServidorDto>().ReverseMap();
            CreateMap<RepositorioServicio, CreateServicioRepositorioDto>().ReverseMap();
            CreateMap<Action, CreateActivoDto>().ReverseMap();
        }
    }
}
