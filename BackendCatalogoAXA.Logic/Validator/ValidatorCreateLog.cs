using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoLog;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateLog : AbstractValidator<CreateLogDto>
    {
        public ValidatorCreateLog(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("Codigo es requerido")
                .CodigoValido(50)
                .YaExisteAsync(
                    context,
                    (ctx, codigo) => ctx.Set<Log>()
                        .AnyAsync(l => l.Codigo.ToUpper() == codigo.ToUpper()),
                    "Codigo"
                );

            RuleFor(x => x.RutaLog)
                .NotEmpty().WithMessage("RutaLog es requerido")
                .MaximumLength(300)
                .WithMessage("RutaLog no debe superar 300 caracteres");

            RuleFor(x => x.ServicioId)
                .IdOpcionalValido("ServicioId")
                .NoExisteIdRelacionAsync(
                    context,
                    (ctx, id) => ctx.Set<Servicio>()
                        .AnyAsync(s => s.ServicioId == id),
                    "ServicioId"
                );

        }
    }
}
