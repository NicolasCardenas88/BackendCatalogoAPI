
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateUnidadNegocio : AbstractValidator<CreateUnidadNegocioDto>
    {
        public ValidatorCreateUnidadNegocio (CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Nombre).NombreValido(50)
            .YaExisteAsync(
                    context,
            (ctx, nombre) => ctx.Set<UnidadNegocio>().AnyAsync(a => a.Nombre == nombre),
                "Nombre"
            );
        }
    }
}
