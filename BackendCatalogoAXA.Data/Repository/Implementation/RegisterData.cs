using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class RegisterData(CatalogoServiciosAxaContext axaContext, IMapper mapper) : IRegisterData
    {
        private readonly CatalogoServiciosAxaContext _context = axaContext;
        private readonly IMapper _mapper = mapper;
        public async Task<bool> RegisterLogicAsync<T>(T crearServicioDto)
        {
            try
            {
                _context.Add(crearServicioDto);
                var response = await _context.SaveChangesAsync();
                if (response < 0)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
            }
            return true;
        }
    }
}
