using AutoMapper;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Model.Dto.DtoFiltroServicio;
using BackendCatalogoAXA.Model.Dto.DtoServicio;
using BackendCatalogoAXA.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;


namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ServiceLogic(IGetData getData, IRegisterData register,
        IValidadationService validadationService,
        IMapper mapper
        ) : IServiceLogic
    {
        private readonly IGetData _getData = getData;
        private readonly IRegisterData _register = register;
        private readonly IValidadationService _validationService = validadationService;
        private readonly IMapper _mapper = mapper;

        public async Task<DetailsServicioDto> FindServicioByIdAsync(int id)
        {
            return await _getData.FindServicioByIdAsync(id);
           
        }
        public async Task<IEnumerable<DetailsServicioDto>> FindServiciosByFiltroAsync(FiltroServicioDto filtro)
        {
            return await _getData.FindServiciosByFiltroAsync(filtro);
        }

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

    }
}
