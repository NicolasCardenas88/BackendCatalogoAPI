using BackendCatalogoAXA.Model.Dto.DtoFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IFrameworkLogic
    {
        Task<List<FrameworkDto>> GetAllAsync();
    }
}
