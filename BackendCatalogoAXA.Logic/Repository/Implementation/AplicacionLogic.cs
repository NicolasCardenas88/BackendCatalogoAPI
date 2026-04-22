using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class AplicacionLogic(IAplicacionData data) : IAplicacionLogic
    {
        private readonly IAplicacionData _data = data;

        public async Task<List<AplicacionDto>> getAllAsync()
        {
            return await _data.getAllAsync();
        }
    }
}
