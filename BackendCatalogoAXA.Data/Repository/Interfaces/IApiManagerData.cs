using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Interfaces
{
    public interface IApiManagerData
    {
        Task<List<ApiManagerDto>> getAllAsync();
    }
}
