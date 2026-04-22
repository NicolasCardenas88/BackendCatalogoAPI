using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Interfaces
{
    public interface IApiManagerLogic
    {
        Task<List<ApiManagerDto>> getAllAsync();
    }
}
