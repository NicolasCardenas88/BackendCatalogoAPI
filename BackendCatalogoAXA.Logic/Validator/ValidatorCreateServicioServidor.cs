using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoServicioServidor;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateServicioServidor : AbstractValidator<CreateServicioServidorDto>
    {
        public ValidatorCreateServicioServidor(CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.ServidorId).IdRelacionValido("ServidorId")
                .NoExisteIdRelacionAsync(context, (ctx, servidorId) => ctx.Set<Servidor>().AnyAsync(s => s.ServidorId == servidorId), "ServidorId");
            RuleFor(x => x.Puerto).GreaterThan(0).WithMessage($"El Puerto debe ser mayor a 0").NotEmpty().WithMessage("El Puerto no puede estar vacio");
            RuleFor(x => x.EstadoId).IdRelacionValido("EstadoId").NoExisteIdRelacionAsync(
                context, (ctx, estadoId) => ctx.Set<Estado>().AnyAsync(s => s.EstadoId == estadoId), "EstadoId");
            RuleFor(x => x.AmbienteId).IdRelacionValido("AmbienteId").NoExisteIdRelacionAsync(
                context, (ctx, ambienteId) => ctx.Set<Ambiente>().AnyAsync(s => s.AmbienteId == ambienteId), "AmbienteId");
        }
    }
}