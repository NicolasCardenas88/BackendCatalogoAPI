using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateModulo : AbstractValidator<CreateModuloDto>
    {
        public ValidatorCreateModulo (CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Codigo).CodigoValido(10).YaExisteAsync(
                context, (ctx, codigo) =>
                ctx.Set<Aplicacion>().AnyAsync(s => s.Codigo == codigo), "Codigo"
                );
            RuleFor(x => x.AplicacionId).IdRelacionValido("AplicacionId").NoExisteIdRelacionAsync
                (
                  context, (ctx, aplicacionId) => ctx.Set<Aplicacion>().AnyAsync(s => s.AplicacionId == aplicacionId), "AplicacionId"

                );
            RuleFor(x => x.Nombre).NombreValido(200);
        }
    }
}
