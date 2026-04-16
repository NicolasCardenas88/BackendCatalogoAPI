using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoApimanager;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateApiManager : AbstractValidator<CreateApiManagerDto>
    {
        public ValidatorCreateApiManager(CatalogoServiciosAxaContext context) {
            RuleFor(x => x.Codigo).CodigoValido(10).YaExisteAsync(context, (ctx, codigo) =>
            ctx.Set<Apimanager>().AnyAsync(s => s.Codigo == codigo),"Codigo");
            RuleFor(x => x.ServicioId).IdRelacionValido("ServicioId")
                .NoExisteIdRelacionAsync
                (context, (ctx, servicioId) => ctx.Set<Servicio>().AnyAsync(s => s.ServicioId == servicioId), "ServicioId");;
            RuleFor(x=> x.Catalogo).DescripcionValidaOpcional("Catalogo",200);
            RuleFor(x => x.NombreApi).DescripcionValidaOpcional("NombreApi", 200);
            RuleFor(x => x.Version).DescripcionValidaOpcional("Version", 20);
            RuleFor(x => x.Recurso).DescripcionValidaOpcional("Recurso", 500);
            RuleFor(x => x.MetodoHttpID).IdRelacionValido("MetodoHttpID")
                .NoExisteIdRelacionAsync
                (context, (ctx, metodoHttp) => ctx.Set<MetodoHttp>().AnyAsync(s => s.MetodoHttpid == metodoHttp), "MetodoHttpID");;
            RuleFor(x => x.Url).UrlValida("Url", 1000);
            RuleFor(x => x.AmbienteId).IdRelacionValido("AmbienteId")
                .NoExisteIdRelacionAsync
                (context, (ctx, ambiente) => ctx.Set<Ambiente>().AnyAsync(s => s.AmbienteId == ambiente), "AmbienteId"); ;
        }   

    }
}
