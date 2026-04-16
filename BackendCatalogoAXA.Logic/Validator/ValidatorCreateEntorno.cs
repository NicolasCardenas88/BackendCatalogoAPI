using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoEntorno;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateEntorno : AbstractValidator<CreateEntornoDto>
    {
        public ValidatorCreateEntorno(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Nombre).NombreValido(50)
                .YaExisteAsync(
                        context,
                (ctx, nombre) => ctx.Set<Entorno>().AnyAsync(a => a.Nombre == nombre),
                "Nombre"
                );
        }
    }
}
