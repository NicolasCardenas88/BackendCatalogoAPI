using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoRepositorio;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateRepositorio : AbstractValidator<CreateRepositorioDto>
    {
        public ValidatorCreateRepositorio(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Codigo).CodigoValido(10).YaExisteAsync(
                context, (ctx, codigo) =>
                ctx.Set<Repositorio>().AnyAsync(s => s.Codigo == codigo), "Codigo"
                );
            RuleFor(x => x.UrlRepositorio).UrlValida("UrlRepositorio", 500);
            RuleFor(x => x.UrlLibrerias).UrlValida("UrlLibrerias", 500);
        }
    }
}
