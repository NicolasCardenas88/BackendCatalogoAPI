using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoMotorDB;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateMotorDb : AbstractValidator<CreateMotorDbDto>
    {
        public ValidatorCreateMotorDb(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Nombre).NombreValido(100).YaExisteAsync(
                context, (ctx, nombre) =>
                ctx.Set<MotorBd>().AnyAsync(s => s.Nombre == nombre), "Nombre"
                );
        }
    }
}
