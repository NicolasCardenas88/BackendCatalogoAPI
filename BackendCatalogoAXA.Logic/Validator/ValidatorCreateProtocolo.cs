using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoProtocolo;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateProtocolo : AbstractValidator<CreateProtocoloDto>
    {
        public ValidatorCreateProtocolo(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Nombre).NombreValido(50).YaExisteAsync(
               context, (ctx, nombre) =>
                ctx.Set<Protocolo>().AnyAsync(s => s.Nombre == nombre), "Nombre");
        }
    }
}
