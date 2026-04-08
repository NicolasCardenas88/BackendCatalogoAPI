using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class AmbienteLogic(IAmbienteData data) : IAmbienteLogic
    {
        private readonly IAmbienteData _data = data;

        public async Task<List<AmbienteDto>> getAllAsync()
        {
            var resp = await _data.getAllAsync();

            return resp.Select(a => new AmbienteDto
            {
                Codigo = a.Codigo,
                Descripcion = a.Descripcion,
            }).ToList();
        }
    }
}
