using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Data.Dto.DtoAmbiente;
using BackendCatalogoAXA.Data.Dto.DtoApimanager;
using BackendCatalogoAXA.Data.Dto.DtoAplicacion;
using BackendCatalogoAXA.Data.Dto.DtoBalanceo;
using BackendCatalogoAXA.Data.Dto.DtoEstado;
using BackendCatalogoAXA.Data.Dto.DtoFramework;
using BackendCatalogoAXA.Data.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Data.Dto.DtoProtocolo;
using BackendCatalogoAXA.Data.Dto.DtoRepositorio;
using BackendCatalogoAXA.Data.Dto.DtoRepositorioColeccion;
using BackendCatalogoAXA.Data.Dto.DtoTipoServicio;
using BackendCatalogoAXA.Data.Dto.DtoUnidadNegocio;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Utils;
using Microsoft.EntityFrameworkCore;


namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class RegisterLogic(IRegisterData registerData,
        IMapper mapper, CatalogoServiciosAxaContext context) : IRegisterLogic
    {
        private readonly IRegisterData _register = registerData;
        private readonly IMapper _mapper = mapper;
        private readonly CatalogoServiciosAxaContext _context = context;

        #region Crear Servicio
        public async Task<bool> RegisterServiceAsync(CrearServicioDto crearServicioDto)
        {
            // Falta implementación del try para Logger proximamente

            var register = await _register.RegisterLogicAsync(_mapper.Map<Servicio>(crearServicioDto));
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
        public async Task<bool> RegisterApiManagerAsync(CreateApiManagerDto createApiManagerDto)
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
        // where TEntidad : class , en esta parte se refencia que el objeto que se reciba sea de tipo clase 
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

        #region Crear Metodo Http
        public async Task<bool> RegisterMetodoHttpAsync(CreateMetodoHttpDto createMetodoHttpDto)
        {
            try
            {
                var register = await _register.RegisterLogicAsync(_mapper.Map<MetodoHttp>(createMetodoHttpDto));
            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }
        #endregion

        #region Crear Repositorio Coleccion
        public async Task<bool> RegisterRepositorioColeccionAsync(CreateRepositoriosColeccionDto createRepositoriosColeccionDto)
        {
            var register = await _register.RegisterLogicAsync(_mapper.Map<RepositorioColeccion>(createRepositoriosColeccionDto));
            return true;
        }
        #endregion

        #region Crear aplicacion 
        public async Task<bool> RegisterAplicacionAsync(CreateAplicacionDto createAplicacionDto)
        {
            var register = await _register.RegisterLogicAsync(_mapper.Map<Aplicacion>(createAplicacionDto));
            return true;
        }
        #endregion

        #region Crear Modulo con relación a Servicio Modulo
        public async Task<bool> RegisterModuloAsync<TCreateDto, TEntidad, TRelacion>(TCreateDto createDto, int idPadre, Func<int, int, TRelacion> crearRelacion)
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

        #region Crear Tipo de Servicio
         public async Task<bool> RegisterTipoServicioAsync(CreateTipoServicioDto createTipoServicioDto)
        {
            var result = await _register.RegisterLogicAsync(_mapper.Map<TipoServicio>(createTipoServicioDto));
            return true;

        }

        #endregion

        #region Crear estado
        public async Task<bool> RegisterEstadoAsync(CreateEstadoDto createEstadoDto)
        {
            var result = await _register.RegisterLogicAsync(_mapper.Map<Estado>(createEstadoDto));
            return true;
        }
        #endregion

        #region Crear Unidad de Negocio
        public async Task<bool> RegisterUnidadNegocioAsync(CreateUnidadNegocioDto createUnidadNegocioDto)
        {
            var result = await _register.RegisterLogicAsync(_mapper.Map<UnidadNegocio>(createUnidadNegocioDto));
            return true;
        }
        #endregion

        #region Crear Protocolo
        public async Task <bool> RegisterProtocoloAsync (CreateProtocoloDto createProtocoloDto)
        {
            var result = await _register.RegisterLogicAsync(_mapper.Map<Protocolo>(createProtocoloDto));
            return true;
        }

        #endregion

        #region Crear Ambiente
        public async Task <bool> RegisterAmbienteAsync(CreateAmbienteDto createAmbienteDto)
        {
            var result = await _register.RegisterLogicAsync(_mapper.Map<Ambiente>(createAmbienteDto));
            return true;
        }
        #endregion

        #region Crear Repositorio
        public async Task<bool> RegisterRepositorioAsync(CreateRepositorioDto createRepositorioDto)
        {
            var result = await _register.RegisterLogicAsync(_mapper.Map<Repositorio>(createRepositorioDto));
            return true;
        }
        #endregion

        #region Crear Balanceo
        public async Task<bool> RegisterBalanceoAsync(CreateBalanceoDto dto)
        {
            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(s => s.ServicioId == dto.ServicioID);

            if (servicio == null) return false;

            var balanceo = new Balanceo
            {
                Codigo = dto.Codigo,
                Url = dto.URL,
                AmbienteId = (int)dto.AmbienteID
            };

            var balanceoCreado = await _register.RegisterLogicAsync(balanceo);
            if (!balanceoCreado) return false;

            var balanceoServicio = new BalanceoServicio
            {
                BalanceoId = balanceo.BalanceoId,
                ServicioId = (int)dto.ServicioID,
                Urlcompleta = dto.URLCompleta
            };

            return await _register.RegisterLogicAsync(balanceoServicio);
        }


        #endregion

    }
}

