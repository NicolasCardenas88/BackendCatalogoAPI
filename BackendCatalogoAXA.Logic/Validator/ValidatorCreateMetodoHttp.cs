using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoMetodoHttp;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateMetodoHttp : AbstractValidator<CreateMetodoHttpDto>
    {
        public ValidatorCreateMetodoHttp(CatalogoServiciosAxaContext context) 
        {
            RuleFor(x => x.Nombre).NombreValido(10).YaExisteAsync(
                context,
                (ctx, nombre) => ctx.Set<MetodoHttp>().AnyAsync(a => a.Nombre == nombre),
                "Nombre"
                );
        }
        
    }
}
