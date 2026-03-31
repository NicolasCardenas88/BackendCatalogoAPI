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
using BackendCatalogoAXA.Model.Dto.DtoActivo;
using BackendCatalogoAXA.Models;

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
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var yaExisteServicio = await _context.Servicios
                    .AnyAsync(s => s.Codigo == crearServicioDto.Codigo);

                if (yaExisteServicio) 
                    throw new AlreadyExistsException($"Ya existe un Servicio con el Codigo '{crearServicioDto.Codigo}'");

                var servicio = _mapper.Map<Servicio>(crearServicioDto);

                await _context.AddAsync(servicio);
                await _context.SaveChangesAsync();

                var noExiteServidor = !await _context.Servidors.AnyAsync(s => crearServicioDto.RelacionServidor.Select(rs => rs.ServidorId).Contains(s.ServidorId));
                
                if (noExiteServidor)
                    throw new NotFoundException("Alguno de los Servidores relacionados no existe");

                var servidores = _mapper.Map<List<ServicioServidor>>(crearServicioDto.RelacionServidor);
                servidores.ForEach(s => s.ServicioId = servicio.ServicioId);

                var noExisteRepositorio = !await _context.Repositorios.AnyAsync(r => crearServicioDto.RelacionRepositorio.Select(rr => rr.RepositorioId).Contains(r.RepositorioId));

                if (noExisteRepositorio)
                    throw new NotFoundException("Alguno de los Repositorios relacionados no existe");

                var repositorios = _mapper.Map<List<RepositorioServicio>>(crearServicioDto.RelacionRepositorio);
                repositorios.ForEach(r => r.ServicioId = servicio.ServicioId);

                await _context.AddRangeAsync(servidores);
                await _context.AddRangeAsync(repositorios);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
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
                throw new ValidationException("El Codigo no puede superar 10 caracteres");

            var yaExiste = await _context.Apimanagers
                .AnyAsync(a => a.Codigo == createApiManagerDto.Codigo);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un ApiManager con el Codigo '{createApiManagerDto.Codigo}'");

           var noExisteServicio = !await _context.Servicios
                .AnyAsync(b => b.ServicioId == createApiManagerDto.ServicioId);
           
            if (noExisteServicio)
                throw new NotFoundException($"No existe un Servicio con ID '{createApiManagerDto.ServicioId}'");

            var noExisteHttp = !await _context.MetodoHttps.AnyAsync(b=> b.MetodoHttpid == createApiManagerDto.MetodoHttpID);

            if(noExisteHttp)
                throw new NotFoundException($"No existe un Metodo Http con ID '{createApiManagerDto.MetodoHttpID}'");

            var noExisteAmbiente = !await _context.Ambientes.AnyAsync(b => b.AmbienteId != createApiManagerDto.AmbienteId);
            if (noExisteAmbiente)
                throw new NotFoundException($"No existe un Ambiente con ID '{createApiManagerDto.AmbienteId}'");

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
                throw new ValidationException("El ID del servidor debe ser mayor a 0");

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

            if (createMetodoHttpDto.Nombre.Length > 10)
                throw new ValidationException("El Nombre no puede superar 10 caracteres");

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

            var yaExisteCodigo = await _context.RepositorioColeccions.AnyAsync(b => b.Codigo == createRepositoriosColeccionDto.Codigo);
            if (yaExisteCodigo)
                throw new ValidationException($"Ya existe una Colección de Repositorio {createRepositoriosColeccionDto.Codigo} ");
            var noExisteServicio = !await _context.Servicios.AnyAsync(b => b.ServicioId == createRepositoriosColeccionDto.ServicioId);
            if (noExisteServicio)
                throw new NotFoundException($"No existe un Servicio con ID '{createRepositoriosColeccionDto.ServicioId}'");
            if (string.IsNullOrEmpty(createRepositoriosColeccionDto.UrlColeccion))
                throw new ValidationException("El campo URL Coleccion es obligatoria");
            if (createRepositoriosColeccionDto.UrlColeccion.Length > 1000)
                throw new ValidationException("La URL Coleccion no puede superar mas 1000 caracteres");
            if (string.IsNullOrWhiteSpace(createRepositoriosColeccionDto.UrlColeccionAzure))
                throw new ValidationException("El campo URl Coleccion de Azure es obligatorio");
            if (createRepositoriosColeccionDto.UrlColeccionAzure.Length > 1000)
                throw new ValidationException("La URL Coleccion de Azure no puede superar mas 1000 caracteres");

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
                throw new ValidationException("El campo NombreApp es obligatorio");

           var noExisteActivo = !await _context.Activos.AnyAsync(b => b.ActivoId == createAplicacionDto.ActivoId);
            if (noExisteActivo)
                throw new NotFoundException($"No existe un Activo con ID '{createAplicacionDto.ActivoId}'");
            
            if (createAplicacionDto.NombreApp.Length > 200)
                throw new ValidationException("El Nombre no puede superar 200 caracteres");

            var yaExiste = await _context.Aplicacions
                .AnyAsync(a => a.NombreApp == createAplicacionDto.NombreApp);
            
            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe una Aplicacion con el nombre '{createAplicacionDto.NombreApp}'");
            
            if(string.IsNullOrEmpty(createAplicacionDto.DescripcionFuncional))
                throw new ValidationException("El campo DescripcionFuncional es obligatorio, no puede estar vacio");
            
            var noExisteEstado = !await _context.Estados.AnyAsync(b => b.EstadoId == createAplicacionDto.EstadoId);
            
            if(noExisteEstado)
                throw new NotFoundException($"No Existe un estado con el Id {createAplicacionDto.EstadoId}");
            
            var noExiteFramework = !await _context.Frameworks.AnyAsync(b => b.FrameworkId == createAplicacionDto.FrameworkId);
            
            if(noExiteFramework)
                throw new NotFoundException($"No Existe un Framework con el Id {createAplicacionDto.FrameworkId}");
             
            var noExisteUnidadNegocio = !await _context.UnidadNegocios.AnyAsync(b => b.UnidadNegocioId == createAplicacionDto.UnidadNegocioId);
            
            if (string.IsNullOrWhiteSpace(createAplicacionDto.UrlTst))
                throw new ValidationException("El campo UrlTst es obligatorio");
            
            if (createAplicacionDto.UrlTst.Length > 500)
                throw new ValidationException("La URL de TST no puede superar 500 caracteres");

            if (string.IsNullOrWhiteSpace(createAplicacionDto.UrlUat))
                throw new ValidationException("El campo UrlUat es obligatorio");

            if (createAplicacionDto.UrlUat.Length > 500)
                throw new ValidationException("La URL de UAT no puede superar 500 caracteres");


            if (string.IsNullOrWhiteSpace(createAplicacionDto.UrlPrd))
                throw new ValidationException("El campo UrlPrd es obligatorio");

            if (createAplicacionDto.UrlUat.Length > 500)
                throw new ValidationException("La URL de PRD no puede superar 500 caracteres");

            if (noExisteUnidadNegocio)
                throw new NotFoundException($"No Existe una Unidad de Negocio con el Id {createAplicacionDto.UnidadNegocioId}");
            
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
                throw new ValidationException("El ID del Servicio debe ser mayor a 0");

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
                throw new AlreadyExistsException($"Ya existe un TipoServicio con el Nombre '{createTipoServicioDto.Nombre}'");

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
                throw new AlreadyExistsException($"Ya existe una UnidadNegocio con el Nombre '{createUnidadNegocioDto.Nombre}'");

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
            if (string.IsNullOrWhiteSpace(createRepositorioDto.UrlRepositorio))
                throw new ValidationException("El campo Url Repositorio es obligatorio");
            if (createRepositorioDto.UrlLibrerias.Length > 500)
                throw new ValidationException("La URL no puede superar 500 caracteres");
            if( createRepositorioDto.UrlRepositorio.Length > 500)
                throw new ValidationException("La URL no puede superar 500 caracteres");

            var yaExiste = await _context.Repositorios
                .AnyAsync(r => r.Codigo == createRepositorioDto.Codigo);

            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Repositorio con el Codigo '{createRepositorioDto.Codigo}'");

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
        public async Task<bool> RegisterServidorAsync(CreateServidorDto dto)
        {
            if (dto == null)
                throw new ValidationException("El objeto Servidor no puede ser nulo");

            if (string.IsNullOrWhiteSpace(dto.Codigo))
                throw new ValidationException("El campo Codigo es obligatorio");

            if (dto.Codigo.Length > 10)
                throw new ValidationException("El Codigo no debe exceder más de 10 caracteres");

            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");

            if (dto.DiscoHddGb.HasValue && dto.DiscoHddGb <= 0)
                throw new ValidationException("DiscoHddGb debe ser mayor a 0");

            if (dto.MemoriaGb.HasValue && dto.MemoriaGb <= 0)
                throw new ValidationException("MemoriaGb debe ser mayor a 0");

            if (dto.MemoriaActualGb.HasValue && dto.MemoriaActualGb <= 0)
                throw new ValidationException("MemoriaActualGb debe ser mayor a 0");

            if (dto.EspacioDiscoGb.HasValue && dto.EspacioDiscoGb <= 0)
                throw new ValidationException("EspacioDiscoGb debe ser mayor a 0");

            if (dto.EspacioActualDiscoGb.HasValue && dto.EspacioActualDiscoGb <= 0)
                throw new ValidationException("EspacioActualDiscoGb debe ser mayor a 0");

            if (dto.Sockets.HasValue && dto.Sockets <= 0)
                throw new ValidationException("Sockets debe ser mayor a 0");

            if (dto.CantidadScores.HasValue && dto.CantidadScores < 0)
                throw new ValidationException("CantidadScores no puede ser negativo");

            if (!string.IsNullOrWhiteSpace(dto.Ip) &&
                !System.Net.IPAddress.TryParse(dto.Ip, out _))
                throw new ValidationException("El formato de la IP no es válido");

            if (dto.FechaDecomision.HasValue && dto.FechaResponsabilidad.HasValue)
            {
                if (dto.FechaDecomision < dto.FechaResponsabilidad)
                    throw new ValidationException("La FechaDecomision no puede ser menor que FechaResponsabilidad");
            }

            if (dto.CategoriaServidorId.HasValue)
            {
                if (dto.CategoriaServidorId <= 0)
                    throw new ValidationException("CategoriaServidorId debe ser mayor a 0");

                var existe = await _context.CategoriaServidors.AnyAsync(b => b.CategoriaServidorId == dto.CategoriaServidorId.Value);
                if (existe)
                    throw new NotFoundException($"CategoriaServidor con id {dto.CategoriaServidorId} no existe");
            }

            if (dto.EntornoId.HasValue)
            {
                if (dto.EntornoId <= 0)
                    throw new ValidationException("EntornoId debe ser mayor a 0");

                var existe = await _context.CategoriaServidors.AnyAsync(b => b.CategoriaServidorId == dto.CategoriaServidorId.Value);
                if (existe)
                    throw new NotFoundException($"Entorno con id {dto.EntornoId} no existe");
            }

            if (dto.EstadoId.HasValue)
            {
                if (dto.EstadoId <= 0)
                    throw new ValidationException("EstadoId debe ser mayor a 0");

                var existe = await _context.Estados.AnyAsync(b => b.EstadoId == dto.EstadoId.Value);
                if (existe)
                    throw new NotFoundException($"Estado con id {dto.EstadoId} no existe");
            }

            if (dto.UnidadNegocioId.HasValue)
            {
                if (dto.UnidadNegocioId <= 0)
                    throw new ValidationException("UnidadNegocioId debe ser mayor a 0");

                var existe = await _context.UnidadNegocios.AnyAsync(b => b.UnidadNegocioId == dto.UnidadNegocioId.Value);
                if (existe)
                    throw new NotFoundException($"UnidadNegocio con id {dto.UnidadNegocioId} no existe");
            }

            if (dto.SistemaOperativoId.HasValue)
            {
                if (dto.SistemaOperativoId <= 0)
                    throw new ValidationException("SistemaOperativoId debe ser mayor a 0");

                var existe = await _context.SistemaOperativos.AnyAsync(b=> b.SistemaOperativoId == dto.SistemaOperativoId.Value);
                if (!existe)
                    throw new NotFoundException($"SistemaOperativo con id {dto.SistemaOperativoId} no existe");
            }

            if (dto.AmbienteId.HasValue)
            {
                if (dto.AmbienteId <= 0)
                    throw new ValidationException("AmbienteId debe ser mayor a 0");

                var existe = await _context.Ambientes.AnyAsync(b => b.AmbienteId == dto.AmbienteId.Value);  
                if (!existe)
                    throw new NotFoundException($"Ambiente con id {dto.AmbienteId} no existe");
            }

            var entidad = _mapper.Map<Servidor>(dto);

            var result = await _register.RegisterLogicAsync(entidad);

            if (!result)
                throw new DatabaseException("Error al registrar el servidor");

            return true;
        }

        #endregion

        #region Crear Sistema Operativo
        public async Task<bool> RegisterSistemaOperativoAsync(CreateSistemaOperativoDto createSistemaOperativoDto)
        {
                if (createSistemaOperativoDto == null)
                    throw new ValidationException("El objeto Sistema Operativo no puede ser nulo");
                if (string.IsNullOrEmpty(createSistemaOperativoDto.Nombre))
                    throw new ValidationException("El campo Nombre es obligatorio");
                if (createSistemaOperativoDto.Nombre.Length > 200)
                    throw new ValidationException("El nombre no debe exceder más 200 caracteres");
                var yaExiste = await _context.SistemaOperativos.AnyAsync(b => b.Nombre == createSistemaOperativoDto.Nombre);
                if (yaExiste)
                    throw new AlreadyExistsException($"El Sistema Operativo con el Nombre {createSistemaOperativoDto.Nombre} ya existe");
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

        #region Crear Activo
        public async Task<bool> RegisterActivoAsync(CreateActivoDto createActivoDto)
        {
            if (createActivoDto == null)
                throw new ValidationException("El objeto Activo no puede ser nulo");
            if (string.IsNullOrWhiteSpace(createActivoDto.Nombre))
                throw new ValidationException("El campo Nombre es obligatorio");
            if(string.IsNullOrWhiteSpace(createActivoDto.Codigo))
                throw new ValidationException("El campo Codigo es obligatorio");
            if (createActivoDto.Codigo.Length > 10)
                throw new ValidationException("El codigo debe ser menor a 10 caracteres");
            if (createActivoDto.Nombre.Length > 200)
                throw new ValidationException("El nombre debe ser menor a 200 caracteres");
            var yaExiste = await _context.Activos
                .AnyAsync(a => a.Nombre == createActivoDto.Nombre);
            if (yaExiste)
                throw new AlreadyExistsException($"Ya existe un Activo con el Nombre '{createActivoDto.Nombre}'");
            var result = await _register.RegisterLogicAsync(_mapper.Map<Activo>(createActivoDto));
            return true;
        }
        #endregion
    }
}