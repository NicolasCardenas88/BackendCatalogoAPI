using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
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
using BackendCatalogoAXA.Model.Dto.DtoServicioModulo;
using BackendCatalogoAXA.Model.Dto.DtoServidor;
using BackendCatalogoAXA.Model.Dto.DtoSistemaOperativo;
using BackendCatalogoAXA.Model.Dto.DtoTipoServicio;
using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;
using BackendCatalogoAXA.Model.Repository.Interfaces;
using BackendCatalogoAXA.Models;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class RegisterLogic(IRegisterData registerData,
        IMapper mapper, CatalogoServiciosAxaContext context, IValidadationService validadationService) : IRegisterLogic
    {
        private readonly IRegisterData _register = registerData;
        private readonly IMapper _mapper = mapper;
        private readonly CatalogoServiciosAxaContext _context = context;
        private readonly IValidadationService _validationService = validadationService;

        #region Crear Servicio
        public async Task<bool> RegisterServiceAsync(CrearServicioDto crearServicioDto)
        {
                await _validationService.ValidateAsync(crearServicioDto);
                var servicio = _mapper.Map<Servicio>(crearServicioDto);
                await _context.AddAsync(servicio);
                await _context.SaveChangesAsync();

                var servidores = _mapper.Map<List<ServicioServidor>>(crearServicioDto.RelacionServidor);
                servidores.ForEach(s => s.ServicioId = servicio.ServicioId);

                var repositorios = _mapper.Map<List<RepositorioServicio>>(crearServicioDto.RelacionRepositorio);
                repositorios.ForEach(r => r.ServicioId = servicio.ServicioId);

                await _context.AddRangeAsync(servidores);
                await _context.AddRangeAsync(repositorios);
                await _context.SaveChangesAsync();
                return true;

        }
        #endregion

        #region Crear Framework
        public async Task<bool> RegisterFrameworkAsync(CreateFrameworkDto createFrameworkDto)
        {

            await _validationService.ValidateAsync(createFrameworkDto);
            await _register.RegisterLogicAsync(_mapper.Map<Framework>(createFrameworkDto));
            return true;
        }
        #endregion

        #region Crear APIManager
        public async Task<bool> RegisterApiManagerAsync(CreateApiManagerDto createApiManagerDto)
        {
            await _validationService.ValidateAsync(createApiManagerDto);
            await _register.RegisterLogicAsync(_mapper.Map<Apimanager>(createApiManagerDto));
            return true;
        }
        #endregion

        #region Crear Log
        public async Task<bool> RegisterLogAsync(CreateLogDto dto)
        {
            var log = _mapper.Map<Log>(dto);
            await _register.RegisterLogicAsync(log);

            var servicioLog = new ServicioLog
            {
                LogId = log.LogId,
                ServicioId = (int)dto.ServicioId
            };

            await _register.RegisterLogicAsync(servicioLog);

            return true;
        }

       
        #endregion

        #region Crear Metodo Http
        public async Task<bool> RegisterMetodoHttpAsync(CreateMetodoHttpDto createMetodoHttpDto)
        {
            await _validationService.ValidateAsync(createMetodoHttpDto);
            await _register.RegisterLogicAsync(_mapper.Map<MetodoHttp>(createMetodoHttpDto));
            return true;
        }
        #endregion

        #region Crear Repositorio Coleccion
        public async Task<bool> RegisterRepositorioColeccionAsync(CreateRepositoriosColeccionDto createRepositoriosColeccionDto)
        {
            await _validationService.ValidateAsync(createRepositoriosColeccionDto);
            await _register.RegisterLogicAsync(_mapper.Map<RepositorioColeccion>(createRepositoriosColeccionDto));
            return true;
        }
        #endregion

        #region Crear Aplicacion
        public async Task<bool> RegisterAplicacionAsync(CreateAplicacionDto createAplicacionDto)
        {
            await _validationService.ValidateAsync(createAplicacionDto);
            await _register.RegisterLogicAsync(_mapper.Map<Aplicacion>(createAplicacionDto));
            return true;
        }
        #endregion

        #region Crear Modulo con relación a Servicio Modulo
        public async Task<bool> RegisterModuloAsync(CreateModuloDto dto) {
            var modulo = _mapper.Map<Modulo>(dto);
            await _register.RegisterLogicAsync(dto);

            var servicioModulo = new CreateServicioModuloDto
            {
                ServicioId = (int)dto.ServicioId,
                ModuloId = modulo.ModuloId
            };
            await _register.RegisterLogicAsync(servicioModulo);
            return true;
        }
        #endregion

        #region Crear Tipo de Servicio
        public async Task<bool> RegisterTipoServicioAsync(CreateTipoServicioDto createTipoServicioDto)
        {
            await _validationService.ValidateAsync(createTipoServicioDto);
            await _register.RegisterLogicAsync(_mapper.Map<TipoServicio>(createTipoServicioDto));
            return true;
        }
        #endregion

        #region Crear Estado
        public async Task<bool> RegisterEstadoAsync(CreateEstadoDto createEstadoDto)
        {
            await _validationService.ValidateAsync(createEstadoDto);
            await _register.RegisterLogicAsync(_mapper.Map<Estado>(createEstadoDto));
            return true;
        }
        #endregion

        #region Crear Unidad de Negocio
        public async Task<bool> RegisterUnidadNegocioAsync(CreateUnidadNegocioDto createUnidadNegocioDto)
        {
            await _validationService.ValidateAsync(createUnidadNegocioDto);
            await _register.RegisterLogicAsync(_mapper.Map<UnidadNegocio>(createUnidadNegocioDto));
            return true;
        }
        #endregion

        #region Crear Protocolo
        public async Task<bool> RegisterProtocoloAsync(CreateProtocoloDto createProtocoloDto)
        {
            await _validationService.ValidateAsync(createProtocoloDto);
            await _register.RegisterLogicAsync(_mapper.Map<Protocolo>(createProtocoloDto));
            return true;
        }
        #endregion

        #region Crear Ambiente
        public async Task<bool> RegisterAmbienteAsync(CreateAmbienteDto createAmbienteDto)
        {
            await _validationService.ValidateAsync(createAmbienteDto);
            await _register.RegisterLogicAsync(_mapper.Map<Ambiente>(createAmbienteDto));
            return true;
        }
        #endregion

        #region Crear Repositorio
        public async Task<bool> RegisterRepositorioAsync(CreateRepositorioDto createRepositorioDto)
        {
            await _validationService.ValidateAsync(createRepositorioDto);
            await _register.RegisterLogicAsync(_mapper.Map<Repositorio>(createRepositorioDto));
            return true;
        }
        #endregion

        #region Crear Balanceo
        public async Task<bool> RegisterBalanceoAsync(CreateBalanceoDto dto)
        {
            await _validationService.ValidateAsync(dto);
            var balanceo = new Balanceo
            {
                Codigo = dto.Codigo,
                Url = dto.URL,
                AmbienteId = (int)dto.AmbienteID
            };

            await _register.RegisterLogicAsync(balanceo);

            var balanceoServicio = new BalanceoServicio
            {
                BalanceoId = balanceo.BalanceoId,
                ServicioId = (int)dto.ServicioID,
                Urlcompleta = dto.URLCompleta
            };

            await _register.RegisterLogicAsync(balanceoServicio);
            return true;
        }
        #endregion

        #region Crear Servidor
        public async Task<bool> RegisterServidorAsync(CreateServidorDto createServidorDto)
        {

            await _validationService.ValidateAsync(createServidorDto);
            var entidad = _mapper.Map<Servidor>(createServidorDto);
            var result = await _register.RegisterLogicAsync(entidad);
            return true;
        }

        #endregion

        #region Crear Sistema Operativo
        public async Task<bool> RegisterSistemaOperativoAsync(CreateSistemaOperativoDto createSistemaOperativoDto)
        {
            await _validationService.ValidateAsync(createSistemaOperativoDto);
            var result = await _register.RegisterLogicAsync(_mapper.Map<SistemaOperativo>(createSistemaOperativoDto));
            return true;
        }
        #endregion

        #region Crear Motor db
        public async Task<bool> RegisterMotorDbAsync(CreateMotorDbDto createMotorDbDto)
        {
            await _validationService.ValidateAsync(createMotorDbDto);
            var result = await _register.RegisterLogicAsync(_mapper.Map<MotorBd>(createMotorDbDto));
            return true;
        }
        #endregion

        #region Crear Categoria Servidor
        public async Task<bool> RegisterCategoriaServidorAsync(CreateCategoriaServidorDto createCategoriaServidorDto)
        {
            await _validationService.ValidateAsync(createCategoriaServidorDto);
            var result = await _register.RegisterLogicAsync(_mapper.Map<CategoriaServidor>(createCategoriaServidorDto));
            return true;
        }
        #endregion

        #region Crear Entorno
        public async Task<bool> RegisterEntornoAsync(CreateEntornoDto createEntornoDto)
        {
            await _validationService.ValidateAsync(createEntornoDto);
            var result = await _register.RegisterLogicAsync(_mapper.Map<Entorno>(createEntornoDto));
            return true;
        }
        #endregion

        #region Crear Activo
        public async Task<bool> RegisterActivoAsync(CreateActivoDto createActivoDto)
        {
            await _validationService.ValidateAsync(createActivoDto);
            var result = await _register.RegisterLogicAsync(_mapper.Map<Activo>(createActivoDto));
            return true;
        }
        #endregion
    }
}