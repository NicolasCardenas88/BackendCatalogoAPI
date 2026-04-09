using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Model.Dto.DtoFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class FrameworkData(CatalogoServiciosAxaContext context) : IFrameworkData
    {
        private readonly CatalogoServiciosAxaContext _context = context;
        public async Task<List<FrameworkDto>> getAllAsync()
        {
            return await _context.Frameworks.AsNoTracking().Select(f => new FrameworkDto
            {
                Nombre = f.Nombre
            })
            .ToListAsync();
        }
    }
}
