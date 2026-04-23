using BackendCatalogoAXA.Model.Dto.DtoSistemaOperativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface ISistemaOperativoLogic
    {
        Task<List<SistemaOperativoDto>> GetAllAsync();
    }
}
