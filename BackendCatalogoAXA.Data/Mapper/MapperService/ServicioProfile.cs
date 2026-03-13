using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.DtoAmbiente;
using BackendCatalogoAXA.Data.Dto.DtoApimanager;
using BackendCatalogoAXA.Data.Dto.DtoBalanceo;
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
            CreateMap<Servicio, DetailsServicioDto>()//ForMember se usa para traer valores en especifico
                .ForMember(dest => dest.ApiManager,//Apunta al dto
                    opt => opt.MapFrom(src => src.Apimanagers)) //apunta a la entidad
                .ForMember(dest => dest.BalanceoServicios,
                    opt => opt.MapFrom(src => src.BalanceoServicios))
                .ForMember(dest => dest.ServicioModulos,
                    opt => opt.MapFrom(src => src.ServicioModulos))
                .ForMember(dest => dest.ServicioLogs,
                    opt => opt.MapFrom(src => src.ServicioLogs));
            CreateMap<Apimanager, ApiManagerDto>();
            CreateMap<MetodoHttp, MetodoHttpDto>();
            CreateMap<Ambiente, AmbienteDto>();
            CreateMap<BalanceoServicio, BalanceoServicioDto>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Urlcompleta));
            CreateMap<ServicioModulo, ServicioModuloDto>();
            CreateMap<Modulo, ModuloDto>();
            CreateMap<ServicioLog, ServicioLogDto>();
            CreateMap<Log, LogDto>();
        }
    }
}
