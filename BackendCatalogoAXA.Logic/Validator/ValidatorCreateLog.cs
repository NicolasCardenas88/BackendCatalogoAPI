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
            RuleFor(x => x.Codigo).CodigoValido(50).YaExisteAsync(
            context, (ctx, codigo) =>
            ctx.Set<Aplicacion>().AnyAsync(s => s.Codigo == codigo), "Codigo"
             );
            RuleFor(x => x.RutaLog).DescripcionValida(500);

        }
    }
}
