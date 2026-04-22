using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Model.Dto.DtoActivo;
using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using BackendCatalogoAXA.Model.Dto.DtoBalanceo;
using BackendCatalogoAXA.Model.Dto.DtoCategoriaServidor;
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
            var modulo = new Modulo
            {
                Codigo = dto.Codigo,
                Nombre = dto.Nombre,
                AplicacionId = (int)dto.AplicacionId
            };
            await _register.RegisterLogicAsync(modulo);

            var servicioModulo = new ServicioModulo
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