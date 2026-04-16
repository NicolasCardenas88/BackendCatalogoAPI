using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoActivo;
using BackendCatalogoAXA.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateActivo : AbstractValidator<CreateActivoDto>
    {
        public ValidatorCreateActivo(CatalogoServiciosAxaContext context) 
        { 
            RuleFor(x => x.Codigo).CodigoValido(10).YaExisteAsync(context, (ctx, codigo) =>
            ctx.Set<Activo>().AnyAsync(s => s.Codigo == codigo), "Codigo");
            RuleFor(x => x.Nombre).NombreValido(200);
            RuleFor(x => x.TieneMFA).Must(x => x == null || x == true || x == false)
            .WithMessage("TieneMFA debe ser true, false o null");
        }
    }
}
