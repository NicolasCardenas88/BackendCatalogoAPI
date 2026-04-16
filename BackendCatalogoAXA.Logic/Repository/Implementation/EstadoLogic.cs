
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoEstado;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class EstadoLogic(IEstadoData data) : IEstadoLogic
    {

        private readonly IEstadoData _data = data;

        public async Task<List<EstadoDto>> GetAllAsync()
        {
            return await _data.GetAllAsync();
        }
    }
}
