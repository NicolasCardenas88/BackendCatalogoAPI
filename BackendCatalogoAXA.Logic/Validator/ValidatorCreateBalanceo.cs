using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoBalanceo;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateBalanceo : AbstractValidator<CreateBalanceoDto>
    {
        public ValidatorCreateBalanceo(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Codigo).CodigoValido(10).YaExisteAsync(
                context, (ctx, codigo) =>
                ctx.Set<Balanceo>().AnyAsync(s => s.Codigo == codigo), "Codigo"
                );
            RuleFor(x => x.URL).UrlValida("URL",500);
            RuleFor(x => x.AmbienteID).IdOpcionalValido("AmbienteID").NoExisteIdRelacionAsync
                 (context, (ctx, balanceoId) => ctx.Set<Ambiente>().AnyAsync(s => s.AmbienteId == balanceoId), "BalanceoId");
            RuleFor(x => x.ServicioID).IdOpcionalValido("ServicioID").NoExisteIdRelacionAsync(
                context, (ctx, servicioId) => ctx.Set<Servicio>().AnyAsync(s => s.ServicioId == servicioId), "ServicioId"
                );
            RuleFor(x => x.URLCompleta).UrlValida("URLCompleta", 500);
                
        }
    }
}
