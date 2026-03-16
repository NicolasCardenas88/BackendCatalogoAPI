using AutoMapper;
using AutoMapper.QueryableExtensions;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.DtoAmbiente;
using BackendCatalogoAXA.Data.Dto.DtoApimanager;
using BackendCatalogoAXA.Data.Dto.DtoBalanceo;
using BackendCatalogoAXA.Data.Dto.DtoFiltroServicio;
using BackendCatalogoAXA.Data.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Data.Dto.DtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoServicioModulo;
using BackendCatalogoAXA.Data.Dto.Modulo;
using BackendCatalogoAXA.Data.Mapper.MapperService;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class GetData(CatalogoServiciosAxaContext  axaContext, IMapper mapper) : IGetData
    {
        //Se llama a interfaz del repository para la comunicación 
        //constructor para interfaces y llamados a LA BASE DE DATOS 
        private readonly CatalogoServiciosAxaContext _context = axaContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DetailsServicioDto> FindServicioByIdAsync(int id)
        {
            var service = await _context.Servicios.
                 AsNoTracking()//se usa para solo traer los datos e optimizar las consultas
                 .AsSplitQuery()// Cuando hay muchas consulta genera un Join Grande
                .Where(p=> p.ServicioId == id)
                .ProjectTo<DetailsServicioDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            return service;
            
        }


        public async Task<List<Servicio>> FindAllServicios()
        {
            return _context.Servicios.ToList();
        }
        #region Servicio Filtro
        public async Task<IEnumerable<DetailsServicioDto>> FindServiciosByFiltroAsync(FiltroServicioDto filtro)
        {
            var query = _context.Servicios.AsNoTracking().AsQueryable();
            // si es direfente de nulo o vacio entra a buscar por url
            if (!string.IsNullOrEmpty(filtro.Url))
                query = query.Where(s => s.Apimanagers
                    .Any(a => a.Url.Contains(filtro.Url))); // existe alguna url igual a la que se envia
            // si es direfente de nulo o vacio entra a buscar por Nombre
            if (!string.IsNullOrEmpty(filtro.Nombre))
                query = query.Where(s => s.Nombre.Contains(filtro.Nombre));

            if (!string.IsNullOrEmpty(filtro.Codigo))
                query = query.Where(s => s.Codigo.Contains(filtro.Codigo));

            if (filtro.TipoServicioId.HasValue)
                query = query.Where(s => s.TipoServicioId == filtro.TipoServicioId);

            if (filtro.EstadoId.HasValue)
                query = query.Where(s => s.EstadoId == filtro.EstadoId);

            return await query
                .Select(s => new DetailsServicioDto
                {
                    Codigo = s.Codigo.Trim(),
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    Propietario = s.Propietario,

                    ApiManager = s.Apimanagers
                        .Where(a => string.IsNullOrEmpty(filtro.Url) ||
                               a.Url.Contains(filtro.Url)) // filtra solo los apimanagers que coinciden
                        .Select(a => new ApiManagerDto
                        {
                            Codigo = a.Codigo.Trim(),
                            NombreApi = a.NombreApi,
                            Url = a.Url,
                            MetodoHttp = a.MetodoHttp == null ? null : new MetodoHttpDto
                            {
                                Nombre = a.MetodoHttp.Nombre
                            },
                            Ambiente = a.Ambiente == null ? null : new AmbienteDto
                            {
                                Codigo = a.Ambiente.Codigo,
                                Descripcion = a.Ambiente.Descripcion
                            }
                        }).ToList(),

                    BalanceoServicios = s.BalanceoServicios
                        .Select(b => new BalanceoServicioDto
                        {
                            Url = b.Urlcompleta
                        }).ToList(),

                    ServicioModulos = s.ServicioModulos
                        .Select(m => new ServicioModuloDto
                        {
                            Modulo = m.Modulo == null ? null : new ModuloDto
                            {
                                Codigo = m.Modulo.Codigo,
                                Nombre = m.Modulo.Nombre
                            }
                        }).ToList()
                })
                .ToListAsync();
        }
        #endregion

    }
}
