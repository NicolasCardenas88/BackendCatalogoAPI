using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoAplicacion;
using BackendCatalogoAXA.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateAplicacion : AbstractValidator<CreateAplicacionDto>
    {
        public ValidatorCreateAplicacion(CatalogoServiciosAxaContext context)
        {
            RuleFor(x=> x.Codigo).CodigoValido(10).YaExisteAsync(context, (ctx, codigo) =>
            ctx.Set<Aplicacion>().AnyAsync(s => s.Codigo == codigo), "Codigo");
            RuleFor(x => x.ActivoId).IdOpcionalValido("ActivoId").NoExisteIdRelacionAsync(
                context,
                (ctx, activoId) => ctx.Set<Activo>().AnyAsync(e => e.ActivoId == activoId),
                "ActivoId");
            RuleFor(x => x.NombreApp).NombreValido(200);
            RuleFor(x => x.DescripcionFuncional).DescripcionValida(500);
            RuleFor(x => x.EstadoId).IdOpcionalValido("EstadoId").NoExisteIdRelacionAsync(
                context,
                (ctx, estadoId) => ctx.Set<Estado>().AnyAsync(e => e.EstadoId == estadoId),
                "ActivoId");
            RuleFor(x => x.FrameworkId).IdOpcionalValido("FrameworkId")
                .NoExisteIdRelacionAsync(
                context, (ctx, frameworkId) => ctx.Set<Framework>().AnyAsync(e => e.FrameworkId == frameworkId), "FrameworkId");
            RuleFor(x => x.UrlTst).UrlValida("UrlTst", 500);
            RuleFor(x => x.UrlUat).UrlValida("UrlUat", 500);
            RuleFor(x => x.UrlPrd).UrlValida("UrlPrd", 500);
            RuleFor(x => x.UnidadNegocioId).IdOpcionalValido("UnidadNegocioId").NoExisteIdRelacionAsync(
                context,
                (ctx, unidadNegocioId) => ctx.Set<UnidadNegocio>().AnyAsync(e => e.UnidadNegocioId == unidadNegocioId),
                "UnidadNegocioId"
                );
        }
    }
}
