using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoTipoServicio;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateTipoServicio : AbstractValidator<CreateTipoServicioDto>
    {
        public ValidatorCreateTipoServicio(CatalogoServiciosAxaContext context)
        {
          RuleFor(x => x.Nombre).NombreValido(100)
                  .YaExisteAsync(
                    context,
                  (ctx, nombre) => ctx.Set<TipoServicio>().AnyAsync(a => a.Nombre == nombre),
                  "Nombre"
                  );
        }
    }
}
