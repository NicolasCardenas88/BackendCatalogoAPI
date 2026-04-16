using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoCategoriaServidor;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateCategoriaServidor : AbstractValidator<CreateCategoriaServidorDto>
    {
        public ValidatorCreateCategoriaServidor(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Nombre).NombreValido(100).YaExisteAsync(
                 context,
                (ctx, nombre) => ctx.Set<CategoriaServidor>().AnyAsync(a => a.Nombre == nombre),
                "Nombre"
                );
        }
    }
}
