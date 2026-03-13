using AutoMapper;
using AutoMapper.QueryableExtensions;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.DtoServicio;
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

    }
}
