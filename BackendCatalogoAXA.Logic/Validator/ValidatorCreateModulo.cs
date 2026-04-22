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
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("Codigo es requerido")
                .CodigoValido(20)
                .YaExisteAsync(
                    context,
                    (ctx, codigo) => ctx.Set<Modulo>()
                        .AnyAsync(m => m.Codigo.ToUpper() == codigo.ToUpper()),
                    "Codigo"
                );

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("Nombre es requerido")
                .NombreValido(150);

            RuleFor(x => x.AplicacionId)
                .NotEmpty().WithMessage("AplicacionId es requerido")
                .GreaterThan(0).WithMessage("AplicacionId debe ser mayor a 0")
                .NoExisteIdRelacionAsync(
                    context,
                    (ctx, id) => ctx.Set<Aplicacion>()
                        .AnyAsync(a => a.AplicacionId == id),
                    "AplicacionId"
                );

            RuleFor(x => x.ServicioId)
                .NotEmpty().WithMessage("ServicioId es requerido")
                .GreaterThan(0).WithMessage("ServicioId debe ser mayor a 0")
                .NoExisteIdRelacionAsync(
                    context,
                    (ctx, id) => ctx.Set<Servicio>()
                        .AnyAsync(s => s.ServicioId == id),
                    "ServicioId"
                );
        }
    }
}
