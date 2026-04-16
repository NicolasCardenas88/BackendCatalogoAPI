using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoSistemaOperativo;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateSistemaOperativo : AbstractValidator<CreateSistemaOperativoDto>
    {
        public ValidatorCreateSistemaOperativo(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Nombre).NombreValido(200).YaExisteAsync(context, (ctx, nombre) =>
            ctx.Set<SistemaOperativo>().AnyAsync(s => s.Nombre == nombre), "Nombre");
        }
    }
}
