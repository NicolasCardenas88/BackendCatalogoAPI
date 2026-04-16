using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.CrearServicioDtoServicio;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateServicio : AbstractValidator<CrearServicioDto>
    {
        public ValidatorCreateServicio(CatalogoServiciosAxaContext context) 
        {
            RuleFor(x => x.Codigo)
            .NotEmpty().WithMessage("Codigo es requerido")
            .CodigoValido(10)
            .YaExisteAsync(
                context,
                (ctx, codigo) => ctx.Set<Servicio>().AnyAsync(s => s.Codigo == codigo),
                "Codigo"
            );

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("Nombre es requerido")
                .NombreValido(200)
                .YaExisteAsync(
                    context,
                    (ctx, nombre) => ctx.Set<Servicio>().AnyAsync(s => s.Nombre == nombre),
                    "Nombre"
                );

            RuleFor(x => x.TipoServicioId)
                .NotEmpty().WithMessage("TipoServicioId es requerido")
                .GreaterThan(0).WithMessage("TipoServicioId debe ser mayor a 0")
                .NoExisteIdRelacionAsync(
                    context,
                    (ctx, id) => ctx.Set<TipoServicio>().AnyAsync(t => t.TipoServicioId == id),
                    "TipoServicioId"
                );

            RuleFor(x => x.ProtocoloId)
                .IdOpcionalValido("ProtocoloId")
                .NoExisteIdRelacionAsync(
                    context,
                    (ctx, id) => ctx.Set<Protocolo>().AnyAsync(p => p.ProtocoloId == id),
                    "ProtocoloId"
                );

            RuleFor(x => x.FrameworkId)
                .IdOpcionalValido("FrameworkId")
                .NoExisteIdRelacionAsync(
                    context,
                    (ctx, id) => ctx.Set<Framework>().AnyAsync(f => f.FrameworkId == id),
                    "FrameworkId"
                );

            RuleFor(x => x.EstadoId)
                .NotEmpty().WithMessage("EstadoId es requerido")
                .GreaterThan(0)
                .NoExisteIdRelacionAsync(
                    context,
                    (ctx, id) => ctx.Set<Estado>().AnyAsync(e => e.EstadoId == id),
                    "EstadoId"
                );

            RuleFor(x => x.Descripcion)
                .DescripcionValidaOpcional("Descripcion", 500);

            RuleFor(x => x.Propietario)
                .MaximumLength(200)
                .WithMessage("Propietario no debe superar 200 caracteres");

            RuleFor(x => x.UnidadNegocioId)
                .IdOpcionalValido("UnidadNegocioId")
                .NoExisteIdRelacionAsync(
                    context,
                    (ctx, id) => ctx.Set<UnidadNegocio>().AnyAsync(u => u.UnidadNegocioId == id),
                    "UnidadNegocioId"
                );

            RuleForEach(x => x.RelacionServidor)
                .SetValidator(new ValidatorCreateServicioServidor(context));

            RuleForEach(x => x.RelacionRepositorio)
                .SetValidator(new ValidatorCreateServicioRepositorio(context));
        }
    }
    
}
