using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoEstado;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateEstado : AbstractValidator<CreateEstadoDto>
    {
        public ValidatorCreateEstado(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Nombre).NombreValido(50).YaExisteAsync(
                  context,
                (ctx, nombre) => ctx.Set<Estado>().AnyAsync(a => a.Nombre == nombre),
                "Nombre");
        }
    }
}
