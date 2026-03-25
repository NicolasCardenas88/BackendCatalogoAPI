using AutoMapper;
using BackendCatalogoAXA.Model.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using BackendCatalogoAXA.Model.Dto.DtoBalanceo;
using BackendCatalogoAXA.Model.Dto.DtoCategoriaServidor;
using BackendCatalogoAXA.Model.Dto.DtoEntorno;
using BackendCatalogoAXA.Model.Dto.DtoEstado;
using BackendCatalogoAXA.Model.Dto.DtoFramework;
using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;
using BackendCatalogoAXA.Model.Dto.DtoMotorDB;
using BackendCatalogoAXA.Model.Dto.DtoProtocolo;
using BackendCatalogoAXA.Model.Dto.DtoRepositorio;
using BackendCatalogoAXA.Model.Dto.DtoRepositorioColeccion;
using BackendCatalogoAXA.Model.Dto.DtoServidor;
using BackendCatalogoAXA.Model.Dto.DtoSistemaOperativo;
using BackendCatalogoAXA.Model.Dto.DtoTipoServicio;
using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;
using BackendCatalogoAXA.Model.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Exceptions;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Utils;
using Microsoft.EntityFrameworkCore;
using BackendCatalogoAXA.Data.Context;

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
            if (crearServicioDto == null)
                throw new ValidationException("El objeto Servicio no puede ser nulo");

            if (string.IsNullOrWhiteSpace(crearServicioDto.Codigo))
                throw new ValidationException("El campo Codigo es obligatorio");

            if (crearServicioDto.Codigo.Length > 10)
                throw new ValidationException("El Codigo no puede superar 10 caracteres");

            if (string.IsNullOrWhiteSpace(crearServicioDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (crearServicioDto.Nombre.Length > 200)
                throw new ValidationException("El Nombre no puede superar 200 caracteres");

            var yaExiste = await _context.Servicios
                .AnyAsync(s => s.Codigo == crearServicioDto.Codigo);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Servicio con el Codigo '{crearServicioDto.Codigo}'");

            await _register.RegisterLogicAsync(_mapper.Map<Servicio>(crearServicioDto));
            return true;
        }
        #endregion

        #region Crear Framework
        public async Task<bool> RegisterFrameworkAsync(CreateFrameworkDto createFrameworkDto)
        {
            if (createFrameworkDto == null)
                throw new ValidationException("El objeto Framework no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createFrameworkDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (createFrameworkDto.Nombre.Length > 100)
                throw new ValidationException("El Nombre no puede superar 100 caracteres");

            var yaExiste = await _context.Frameworks
                .AnyAsync(f => f.Nombre == createFrameworkDto.Nombre);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Framework con el nombre '{createFrameworkDto.Nombre}'");

            await _register.RegisterLogicAsync(_mapper.Map<Framework>(createFrameworkDto));
            return true;
        }
        #endregion

        #region Crear APIManager
        public async Task<bool> RegisterApiManagerAsync(CreateApiManagerDto createApiManagerDto)
        {
            if (createApiManagerDto == null)
                throw new ValidationException("El objeto ApiManager no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createApiManagerDto.Codigo))
                throw new ValidationException("El campo Codigo es obligatorio");

            if (createApiManagerDto.Codigo.Length > 10)
                throw new ValidationException("El Codfigo no puede superar 10 caracteres");

            var yaExiste = await _context.Apimanagers
                .AnyAsync(a => a.Codigo == createApiManagerDto.Codigo);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un ApiManager con el Codigo '{createApiManagerDto.Codigo}'");

           var noExisteServicio = !await _context.Servicios
                .AnyAsync(b => b.ServicioId == createApiManagerDto.ServicioId);
            if (noExisteServicio)
                throw new NotFoundException($"No existe un Servicio con ID '{createApiManagerDto.ServicioId}'");

            await _register.RegisterLogicAsync(_mapper.Map<Apimanager>(createApiManagerDto));
            return true;
        }
        #endregion

        #region Crear Log
        public async Task<bool> RegisterLogAsync<TCreateDto, TEntidad, TRelacion>(
            TCreateDto createDto,
            int idPadre,
            Func<int, int, TRelacion> crearRelacion)
            where TEntidad : class
            where TRelacion : class
        {
            if (createDto == null)
                throw new ValidationException("El objeto Log no puede ser nulo");

            if (idPadre <= 0)
                throw new ValidationException("El ID padre debe ser mayor a 0");

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
            if (createMetodoHttpDto == null)
                throw new ValidationException("El objeto MetodoHttp no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createMetodoHttpDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (createMetodoHttpDto.Nombre.Length > 50)
                throw new ValidationException("El Nombre no puede superar 50 caracteres");

            var yaExiste = await _context.MetodoHttps
                .AnyAsync(m => m.Nombre == createMetodoHttpDto.Nombre);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un MetodoHttp con el nombre '{createMetodoHttpDto.Nombre}'");

            await _register.RegisterLogicAsync(_mapper.Map<MetodoHttp>(createMetodoHttpDto));
            return true;
        }
        #endregion

        #region Crear Repositorio Coleccion
        public async Task<bool> RegisterRepositorioColeccionAsync(CreateRepositoriosColeccionDto createRepositoriosColeccionDto)
        {
            if (createRepositoriosColeccionDto == null)
                throw new ValidationException("El objeto RepositorioColeccion no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createRepositoriosColeccionDto.Codigo))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (createRepositoriosColeccionDto.Codigo.Length > 10)
                throw new ValidationException("El Codigo no debe ser mayor a 10 caracteres");

            await _register.RegisterLogicAsync(_mapper.Map<RepositorioColeccion>(createRepositoriosColeccionDto));
            return true;
        }
        #endregion

        #region Crear Aplicacion
        public async Task<bool> RegisterAplicacionAsync(CreateAplicacionDto createAplicacionDto)
        {
            if (createAplicacionDto == null)
                throw new ValidationException("El objeto Aplicacion no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createAplicacionDto.NombreApp))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (createAplicacionDto.NombreApp.Length > 200)
                throw new ValidationException("El Nombre no puede superar 200 caracteres");

            var yaExiste = await _context.Aplicacions
                .AnyAsync(a => a.NombreApp == createAplicacionDto.NombreApp);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe una Aplicacion con el nombre '{createAplicacionDto.NombreApp}'");

            await _register.RegisterLogicAsync(_mapper.Map<Aplicacion>(createAplicacionDto));
            return true;
        }
        #endregion

        #region Crear Modulo con relación a Servicio Modulo
        public async Task<bool> RegisterModuloAsync<TCreateDto, TEntidad, TRelacion>(
            TCreateDto createDto,
            int idPadre,
            Func<int, int, TRelacion> crearRelacion)
            where TEntidad : class
            where TRelacion : class
        {
            if (createDto == null)
                throw new ValidationException("El objeto Modulo no puede ser nulo");

            if (idPadre <= 0)
                throw new ValidationException("El ID padre debe ser mayor a 0");

            var servicioExiste = await _context.Servicios
                .AnyAsync(s => s.ServicioId == idPadre);

            if (!servicioExiste)
                throw new NotFoundException($"No existe un Servicio con ID {idPadre}");

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
            if (createTipoServicioDto == null)
                throw new ValidationException("El objeto TipoServicio no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createTipoServicioDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (createTipoServicioDto.Nombre.Length > 100)
                throw new ValidationException("El Nombre no puede superar 100 caracteres");

            var yaExiste = await _context.TipoServicios
                .AnyAsync(t => t.Nombre == createTipoServicioDto.Nombre);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un TipoServicio con el nombre '{createTipoServicioDto.Nombre}'");

            await _register.RegisterLogicAsync(_mapper.Map<TipoServicio>(createTipoServicioDto));
            return true;
        }
        #endregion

        #region Crear Estado
        public async Task<bool> RegisterEstadoAsync(CreateEstadoDto createEstadoDto)
        {
            if (createEstadoDto == null)
                throw new ValidationException("El objeto Estado no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createEstadoDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (createEstadoDto.Nombre.Length > 100)
                throw new ValidationException("El Nombre no puede superar 100 caracteres");

            var yaExiste = await _context.Estados
                .AnyAsync(e => e.Nombre == createEstadoDto.Nombre);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Estado con el nombre '{createEstadoDto.Nombre}'");

            await _register.RegisterLogicAsync(_mapper.Map<Estado>(createEstadoDto));
            return true;
        }
        #endregion

        #region Crear Unidad de Negocio
        public async Task<bool> RegisterUnidadNegocioAsync(CreateUnidadNegocioDto createUnidadNegocioDto)
        {
            if (createUnidadNegocioDto == null)
                throw new ValidationException("El objeto UnidadNegocio no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createUnidadNegocioDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (createUnidadNegocioDto.Nombre.Length > 100)
                throw new ValidationException("El Nombre no puede superar 100 caracteres");

            var yaExiste = await _context.UnidadNegocios
                .AnyAsync(u => u.Nombre == createUnidadNegocioDto.Nombre);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe una UnidadNegocio con el nombre '{createUnidadNegocioDto.Nombre}'");

            await _register.RegisterLogicAsync(_mapper.Map<UnidadNegocio>(createUnidadNegocioDto));
            return true;
        }
        #endregion

        #region Crear Protocolo
        public async Task<bool> RegisterProtocoloAsync(CreateProtocoloDto createProtocoloDto)
        {
            if (createProtocoloDto == null)
                throw new ValidationException("El objeto Protocolo no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createProtocoloDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (createProtocoloDto.Nombre.Length > 50)
                throw new ValidationException("El Nombre no puede superar 50 caracteres");

            var yaExiste = await _context.Protocolos
                .AnyAsync(p => p.Nombre == createProtocoloDto.Nombre);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Protocolo con el nombre '{createProtocoloDto.Nombre}'");

            await _register.RegisterLogicAsync(_mapper.Map<Protocolo>(createProtocoloDto));
            return true;
        }
        #endregion

        #region Crear Ambiente
        public async Task<bool> RegisterAmbienteAsync(CreateAmbienteDto createAmbienteDto)
        {
            if (createAmbienteDto == null)
                throw new ValidationException("El objeto Ambiente no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createAmbienteDto.Codigo))
                throw new ValidationException("El campo Codigo es obligatorio");

            if (createAmbienteDto.Codigo.Length > 3)
                throw new ValidationException("El Codigo no puede superar 3 caracteres");

            if (string.IsNullOrWhiteSpace(createAmbienteDto.Descripcion))
                throw new ValidationException("El campo Descripcion es obligatorio");

            if (createAmbienteDto.Descripcion.Length > 100)
                throw new ValidationException("La Descripcion no puede superar 100 caracteres");

            var yaExiste = await _context.Ambientes
                .AnyAsync(a => a.Codigo == createAmbienteDto.Codigo);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Ambiente con el Codigo '{createAmbienteDto.Codigo}'");

            await _register.RegisterLogicAsync(_mapper.Map<Ambiente>(createAmbienteDto));
            return true;
        }
        #endregion

        #region Crear Repositorio
        public async Task<bool> RegisterRepositorioAsync(CreateRepositorioDto createRepositorioDto)
        {
            if (createRepositorioDto == null)
                throw new ValidationException("El objeto Repositorio no puede ser nulo");

            if (string.IsNullOrWhiteSpace(createRepositorioDto.Codigo))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (createRepositorioDto.Codigo.Length > 200)
                throw new ValidationException("El Nombre no puede superar 200 caracteres");

            if (string.IsNullOrWhiteSpace(createRepositorioDto.UrlLibrerias))
                throw new ValidationException("El campo Url Librerias es obligatorio");

            if (createRepositorioDto.UrlLibrerias.Length > 500)
                throw new ValidationException("La URL no puede superar 500 caracteres");

            var yaExiste = await _context.Repositorios
                .AnyAsync(r => r.Urllibrerias == createRepositorioDto.UrlLibrerias);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Repositorio con la URL '{createRepositorioDto.UrlLibrerias}'");

            await _register.RegisterLogicAsync(_mapper.Map<Repositorio>(createRepositorioDto));
            return true;
        }
        #endregion

        #region Crear Balanceo
        public async Task<bool> RegisterBalanceoAsync(CreateBalanceoDto dto)
        {
            if (dto == null)
                throw new ValidationException("El objeto Balanceo no puede ser nulo");

            if (string.IsNullOrWhiteSpace(dto.Codigo))
                throw new ValidationException("El campo Codigo es obligatorio");

            if (dto.Codigo.Length > 10)
                throw new ValidationException("El Codigo no puede superar 10 caracteres");

            if (string.IsNullOrWhiteSpace(dto.URL))
                throw new ValidationException("El campo URL es obligatorio");

            if (dto.URL.Length > 1000)
                throw new ValidationException("La URL no puede superar 1000 caracteres");

            if (dto.AmbienteID <= 0)
                throw new ValidationException("El AmbienteID debe ser mayor a 0");

            if (dto.ServicioID <= 0)
                throw new ValidationException("El ServicioID debe ser mayor a 0");

            var servicioExiste = await _context.Servicios
                .AnyAsync(s => s.ServicioId == dto.ServicioID);

            if (!servicioExiste)
                throw new NotFoundException($"No existe un Servicio con ID {dto.ServicioID}");

            var ambienteExiste = await _context.Ambientes
                .AnyAsync(a => a.AmbienteId == dto.AmbienteID);

            if (!ambienteExiste)
                throw new NotFoundException($"No existe un Ambiente con ID {dto.AmbienteID}");

            var yaExiste = await _context.Balanceos
                .AnyAsync(b => b.Codigo == dto.Codigo && b.AmbienteId == dto.AmbienteID);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Balanceo con Codigo '{dto.Codigo}' en el Ambiente {dto.AmbienteID}");

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
            var result = await _register.RegisterLogicAsync (_mapper.Map<Servidor>(createServidorDto));
            return true;
        }

        #endregion

        #region Crear Sistema Operativo
        public async Task<bool> RegisterSistemaOperativoAsync(CreateSistemaOperativoDto createSistemaOperativoDto)
        {
            var result = await _register.RegisterLogicAsync(_mapper.Map<SistemaOperativo>(createSistemaOperativoDto));
            return true;
        }
        #endregion

        #region Crear Motor db
        public async Task<bool> RegisterMotorDbAsync(CreateMotorDbDto createMotorDbDto)
        {
            if (createMotorDbDto == null)
                throw new ValidationException("El objeto MotorDB no puede ser nulo");
            if (string.IsNullOrEmpty(createMotorDbDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");
            if (createMotorDbDto.Nombre.Length > 100)
                throw new ValidationException("El nombre no debe exceder más 100 caracteres");
            var yaExiste = await _context.MotorBds.AnyAsync(b => b.Nombre == createMotorDbDto.Nombre);
            if (yaExiste)
                throw new AlreadyExistsException($"El motor de bases de datos con el Nombre {createMotorDbDto.Nombre} ya existe");
            var result = await _register.RegisterLogicAsync(_mapper.Map<MotorBd>(createMotorDbDto));
            return true;
        }
        #endregion

        #region Crear Categoria Servidor
        public async Task<bool> RegisterCategoriaServidorAsync(CreateCategoriaServidorDto createCategoriaServidorDto)
        {
            if (createCategoriaServidorDto == null)
                throw new ValidationException("El objeto Categoria Servidor no puede ser nulo");
            if (string.IsNullOrEmpty(createCategoriaServidorDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");
            if (createCategoriaServidorDto.Nombre.Length > 100)
                throw new ValidationException("El Nombre sebe ser menor a 100 caracteres");
            var yaExiste = await _context.CategoriaServidors.AnyAsync(b => b.Nombre == createCategoriaServidorDto.Nombre);
            if (yaExiste)
                throw new AlreadyExistsException($"La Categoria Servidor con el nombre {createCategoriaServidorDto.Nombre} ya existe");

            var result = await _register.RegisterLogicAsync(_mapper.Map<CategoriaServidor>(createCategoriaServidorDto));
            return true;
        }
        #endregion

        #region Crear Entorno
        public async Task<bool> RegisterEntornoAsync(CreateEntornoDto createEntornoDto)
        {
            if (createEntornoDto == null)
                throw new ValidationException("El objeto Entorno no puede ser nulo");
            if (string.IsNullOrWhiteSpace(createEntornoDto.Nombre))
                throw new ValidationException("El campo Codigo es obligatorio");
            if (createEntornoDto.Nombre.Length > 50)
                throw new ValidationException("El nombre debe ser menor a 50 Caracteres");

            var yaExiste = await _context.Entornos
                           .AnyAsync(s => s.Nombre == createEntornoDto.Nombre);
            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Entorno con el Nombre '{createEntornoDto.Nombre}'");

            var result = await _register.RegisterLogicAsync(_mapper.Map<Entorno>(createEntornoDto));
            return true;
        }
        #endregion 
    }
}