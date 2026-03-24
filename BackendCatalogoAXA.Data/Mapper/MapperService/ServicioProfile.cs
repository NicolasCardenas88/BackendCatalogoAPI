using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoAmbiente;
using BackendCatalogoAXA.Data.Dto.DtoApimanager;
using BackendCatalogoAXA.Data.Dto.DtoAplicacion;
using BackendCatalogoAXA.Data.Dto.DtoBalanceo;
using BackendCatalogoAXA.Data.Dto.DtoEstado;
using BackendCatalogoAXA.Data.Dto.DtoFramework;
using BackendCatalogoAXA.Data.Dto.DtoLog;
using BackendCatalogoAXA.Data.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Data.Dto.DtoModulo;
using BackendCatalogoAXA.Data.Dto.DtoProtocolo;
using BackendCatalogoAXA.Data.Dto.DtoRepositorio;
using BackendCatalogoAXA.Data.Dto.DtoRepositorioColeccion;
using BackendCatalogoAXA.Data.Dto.DtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoServicioModulo;
using BackendCatalogoAXA.Data.Dto.DtoTipoServicio;
using BackendCatalogoAXA.Data.Dto.DtoUnidadNegocio;
using BackendCatalogoAXA.Data.Dto.Modulo;


namespace BackendCatalogoAXA.Data.Mapper.MapperService
{
    public class ServicioProfile : Profile
    {
        public ServicioProfile() {
            CreateMap<Servicio, DetailsServicioDto>().ReverseMap();
            CreateMap<Servicio, CrearServicioDto>().ReverseMap();
            CreateMap<Apimanager, ApiManagerDto>().ReverseMap();
            CreateMap<Apimanager, CreateApiManagerDto>().ReverseMap();
            CreateMap<MetodoHttp, MetodoHttpDto>().ReverseMap();
            CreateMap<MetodoHttp,  CreateMetodoHttpDto>().ReverseMap();
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

        }
    }
}
