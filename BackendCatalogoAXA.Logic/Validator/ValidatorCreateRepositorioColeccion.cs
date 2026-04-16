using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoRepositorioColeccion;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateRepositorioColeccion : AbstractValidator<CreateRepositoriosColeccionDto>
    {
        public ValidatorCreateRepositorioColeccion(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Codigo).CodigoValido(10).YaExisteAsync(
                context, (ctx, codigo) =>
                ctx.Set<RepositorioColeccion>().AnyAsync(s => s.Codigo == codigo), "Codigo"
                );
            RuleFor(x => x.ServicioId).IdRelacionValido("ServicioId").NoExisteIdRelacionAsync(context, (ctx, servicioId) =>
            ctx.Set<Servicio>().AnyAsync(s => s.ServicioId == servicioId), "ServicioId");
            RuleFor(x => x.UrlColeccion).UrlValida("UrlColeccion", 1000);
            RuleFor(x => x.UrlColeccionAzure).UrlValida("UrlColeccionAzure", 1000);
        }
    }
}
