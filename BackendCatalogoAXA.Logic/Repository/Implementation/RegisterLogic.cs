using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class RegisterLogic (IRegisterData registerData,
        IMapper mapper) : IRegisterLogic
    {
        private readonly IRegisterData _register = registerData;
        private readonly IMapper _mapper = mapper;
        public async Task<bool> RegisterLogicAsync(CrearServicioDto crearServicioDto)
        {
            try
            {
                var register = _register.RegisterLogicAsync( _mapper.Map<Servicio>(crearServicioDto));

            }
            catch (Exception ex)
            {

                throw;
            } return true;
        }
    }
}
