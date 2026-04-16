using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoAmbiente;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateAmbiente: AbstractValidator<CreateAmbienteDto>
    {
        public ValidatorCreateAmbiente(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Codigo).CodigoValido(3).YaExisteAsync(
                context, (ctx, codigo) =>
                ctx.Set<Ambiente>().AnyAsync(s => s.Codigo == codigo), "Codigo"
                );
            RuleFor(x => x.Descripcion).DescripcionValidaOpcional("Descripcion",100);
        }

    }
}
