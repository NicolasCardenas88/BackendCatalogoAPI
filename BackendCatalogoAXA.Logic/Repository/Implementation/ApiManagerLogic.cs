using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ApiManagerLogic(IApiManagerData data) : IApiManagerLogic
    {
        private readonly IApiManagerData _data = data;

        public async Task<List<ApiManagerDto>> getAllAsync()
        {
            return await _data.getAllAsync();

        }
    }
}
