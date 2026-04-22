using BackendCatalogoAXA.Model.Dto.DtoFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IFrameworkData
    {
        Task<List<FrameworkDto>> getAllAsync();
    }
}
