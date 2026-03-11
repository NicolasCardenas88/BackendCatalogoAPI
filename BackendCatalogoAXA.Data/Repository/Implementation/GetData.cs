using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Repository.Implementation
{
    public class GetData(CatalogoServiciosAxaContext  axaContext) : IGetData
    {
        //constructor para interfaces y llamados a LA BASE DE DATOS 
        private readonly CatalogoServiciosAxaContext _context = axaContext;
        public async Task<Servicio> FindServicioByIdAsync(int id)
        {
            try
            {
                var response = await _context.Servicios.FirstOrDefaultAsync(
                        p => p.ServicioId == id);
                if (response == null)
                {
                    return new Servicio();
                }
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
