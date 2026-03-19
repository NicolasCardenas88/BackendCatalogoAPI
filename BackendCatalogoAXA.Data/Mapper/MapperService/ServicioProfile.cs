using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoAmbiente;
using BackendCatalogoAXA.Data.Dto.DtoApimanager;
using BackendCatalogoAXA.Data.Dto.DtoBalanceo;
using BackendCatalogoAXA.Data.Dto.DtoFramework;
using BackendCatalogoAXA.Data.Dto.DtoLog;
using BackendCatalogoAXA.Data.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Data.Dto.DtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoServicioModulo;
using BackendCatalogoAXA.Data.Dto.Modulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Mapper.MapperService
{
    public class ServicioProfile : Profile
    {
        public ServicioProfile() {
            CreateMap<Servicio, DetailsServicioDto>().ReverseMap();
            CreateMap<Servicio, CrearServicioDto>().ReverseMap();
            //ForMember se usa para traer valores en especifico
            CreateMap<Apimanager, ApiManagerDto>().ReverseMap();
            CreateMap<Apimanager, CreateApiManagerDto>().ReverseMap();
            CreateMap<MetodoHttp, MetodoHttpDto>().ReverseMap();
            CreateMap<Ambiente, AmbienteDto>().ReverseMap();
            CreateMap<BalanceoServicio, BalanceoServicioDto>().ReverseMap();
            CreateMap<ServicioModulo, ServicioModuloDto>().ReverseMap();
            CreateMap<Modulo, ModuloDto>().ReverseMap();
            CreateMap<ServicioLog, ServicioLogDto>().ReverseMap();
            CreateMap<ServicioLog, CrearServicioDto>().ReverseMap();
            CreateMap<Log, LogDto>().ReverseMap();
            CreateMap<Log, CreateLogDto>().ReverseMap();
            CreateMap<Framework, CreateFrameworkDto>().ReverseMap();
        }
    }
}
