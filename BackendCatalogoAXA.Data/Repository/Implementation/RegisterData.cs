using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Model.Repository.Interfaces;

namespace BackendCatalogoAXA.Model.Repository.Implementation
{
    public class RegisterData(CatalogoServiciosAxaContext axaContext) : IRegisterData
    {
        private readonly CatalogoServiciosAxaContext _context = axaContext;

        #region Repository Register Universal
        public async Task<bool> RegisterLogicAsync<T>(T registerObject)
        {

                await _context.AddAsync(registerObject);
                var response = await _context.SaveChangesAsync();
                if (response < 0)
                {
                    return false;
                }                
       
            return true;
        }
        #endregion
    }
}
