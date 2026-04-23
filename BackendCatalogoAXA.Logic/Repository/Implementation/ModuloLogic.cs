
using AutoMapper;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.Modulo;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ModuloLogic(IModuloData data, IMapper mapper) : IModuloLogic
    {
        private readonly IModuloData _moduloData = data;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ModuloDto>> GetAllAsync()
        {
            // Trae las entidades desde data
            var modulos = await _moduloData.GetAllAsync();

            // Se convierte a DTO
            return _mapper.Map<List<ModuloDto>>(modulos);
        }
    }
}
