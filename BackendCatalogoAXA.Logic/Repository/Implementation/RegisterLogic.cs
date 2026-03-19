using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoApimanager;
using BackendCatalogoAXA.Data.Dto.DtoFramework;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Utils;


namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class RegisterLogic (IRegisterData registerData,
        IMapper mapper) : IRegisterLogic
    {
        private readonly IRegisterData _register = registerData;
        private readonly IMapper _mapper = mapper;


        #region Crear Servicio
        public async Task<bool> RegisterServiceAsync(CrearServicioDto crearServicioDto)
        {
            // Falta implementación del try para Logger proximamente

                var register = await _register.RegisterLogicAsync( _mapper.Map<Servicio>(crearServicioDto));
                 return true;
        }
        #endregion

        #region Crear Framework
        public async Task<bool> RegisterFrameworkAsync(CreateFrameworkDto createFrameworkDto)
        {
            try
            {

                var register = await _register.RegisterLogicAsync(_mapper.Map<Framework>(createFrameworkDto));

            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }
        #endregion

        #region Crear APIManager
        public async Task<bool> RegisterApiManager(CreateApiManagerDto createApiManagerDto)
        {

            try
            {

                var register = await _register.RegisterLogicAsync(_mapper.Map<Apimanager>(createApiManagerDto));

            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }
        #endregion

        #region Crear Log
        // Este metodo es generico se implementa una promesa que al cumplir retorna un valor booleano (true o false)
        // Como parametros recibe un generico Dto, la entidad que se va a crear y la entidad con quien se va a hacer la relacion
        //  Func<int, int, TRelacion> crearRelacion) Funciona los tipos de entrar que va a poseer y TRelacion es el objeto generico que va a retornar
        public async Task<bool> RegisterLogAsync<TCreateDto, TEntidad, TRelacion>(
            TCreateDto createDto,
            int idPadre,
            Func<int, int, TRelacion> crearRelacion)
            where TEntidad : class 
            where TRelacion : class
        {

            var entidad = _mapper.Map<TEntidad>(createDto);
            await _register.RegisterLogicAsync(entidad);
            var idEntidad = Util.ObtenerIdEntidad(entidad);
            var relacion = crearRelacion(idPadre, idEntidad);
            await _register.RegisterLogicAsync(relacion);
            return true;
        }


        #endregion


    }
}
