using AutoMapper;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoMotorDB;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class MotorDBLogic(IMotorDBData data, IMapper mapper) : IMotorDBLogic
    {
        private readonly IMotorDBData _motorDBData = data;
        private readonly IMapper _mapper = mapper;

        public async Task<List<MotorDbDto>> GetAllAsync()
        {
            var motorDB = await _motorDBData.GetAllAsync();
            return _mapper.Map<List<MotorDbDto>>(motorDB);
        }
    }
}
