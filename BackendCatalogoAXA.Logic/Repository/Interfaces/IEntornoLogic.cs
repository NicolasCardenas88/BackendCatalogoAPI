using BackendCatalogoAXA.Model.Dto.DtoEntorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IEntornoLogic
    {
        Task<List<EntornoDto>> GetAllAsync();
    }
}
