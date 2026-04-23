using AutoMapper;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoRepositorio;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class RepositorioLogic(IRepositorioData data, IMapper mapper) : IRepositorioLogic
    {
        private readonly IRepositorioData _repositorioData = data;
        private readonly IMapper _mapper = mapper;

        public async Task<List<RepositorioDto>> GetAllAsync()
        {
            var repositorio = await _repositorioData.GetAllAsync();
            return _mapper.Map<List<RepositorioDto>>(repositorio);
        }
    }
}
