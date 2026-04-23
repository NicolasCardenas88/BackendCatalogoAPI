using AutoMapper;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoRepositorioColeccion;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class RepositorioColeccionLogic(IRepositorioColeccionData data, IMapper mapper) : IRepositorioColeccionLogic
    {
        private readonly IRepositorioColeccionData _repoColeccionData = data;
        private readonly IMapper _mapper = mapper;

        public async Task<List<RepositorioColeccionDto>> GetAllAsync()
        {
            var repoColeccion = await _repoColeccionData.GetAllAsync();
            return _mapper.Map<List<RepositorioColeccionDto>>(repoColeccion);
        }
    }
}
