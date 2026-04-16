using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.CrearServicioDtoServicio;
using BackendCatalogoAXA.Model.Dto.DtoRepositorioServicio;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    internal class ValidatorCreateServicioRepositorio : AbstractValidator<CreateServicioRepositorioDto>
    {
        public ValidatorCreateServicioRepositorio(CatalogoServiciosAxaContext context) {
            RuleFor(x => x.RepositorioId).GreaterThan(0).WithMessage("RepositorioId debe ser mayor que 0").IdRelacionValido("RepositorioId")
                .NoExisteIdRelacionAsync(
                context, (ctx, repositorioId) => ctx.Set<Repositorio>().AnyAsync(s => s.RepositorioId == repositorioId
                ), "RepositorioId");
        }
    }
}