using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoFramework;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateFramework : AbstractValidator<CreateFrameworkDto>
    {
        public ValidatorCreateFramework(CatalogoServiciosAxaContext context) 
        {
            RuleFor(x => x.Nombre).NombreValido(100).YaExisteAsync(
                 context,
                (ctx, nombre) => ctx.Set<Framework>().AnyAsync(a => a.Nombre == nombre),
                "Nombre"
                );
        }
    }
}
