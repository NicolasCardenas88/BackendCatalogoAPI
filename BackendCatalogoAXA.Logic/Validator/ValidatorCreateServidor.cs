using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Logic.Validator.Common;
using BackendCatalogoAXA.Model.Dto.DtoServidor;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Logic.Validator
{
    public class ValidatorCreateServidor : AbstractValidator<CreateServidorDto>
    {
        public ValidatorCreateServidor (CatalogoServiciosAxaContext context)
        {
            RuleFor(x => x.Codigo)
        .CodigoValido(10)
        .YaExisteAsync(context,
            async (ctx, codigo) => await ctx.Set<Servidor>()
                .AnyAsync(s => s.Codigo == codigo),
            "Servidor");

                RuleFor(x => x.Nombre)
                    .NombreValido(200);

            RuleFor(x => x.CategoriaServidorId)
                .IdOpcionalValido("CategoriaServidor")
                .NoExisteIdRelacionAsync(context,
                    async (ctx, id) => await ctx.Set<CategoriaServidor>()
                        .AnyAsync(x => x.CategoriaServidorId == id),
                    "CategoriaServidor");

            RuleFor(x => x.EntornoId)
                .IdOpcionalValido("Entorno")
                .NoExisteIdRelacionAsync(context,
                    async (ctx, id) => await ctx.Set<Entorno>()
                        .AnyAsync(x => x.EntornoId == id),
                    "Entorno");

            RuleFor(x => x.EstadoId)
                .IdOpcionalValido("Estado")
                .NoExisteIdRelacionAsync(context,
                    async (ctx, id) => await ctx.Set<Estado>()
                        .AnyAsync(x => x.EstadoId == id),
                    "Estado");

            RuleFor(x => x.SistemaOperativoId)
                .IdOpcionalValido("SistemaOperativo")
                .NoExisteIdRelacionAsync(context,
                    async (ctx, id) => await ctx.Set<SistemaOperativo>()
                        .AnyAsync(x => x.SistemaOperativoId == id),
                    "SistemaOperativo");

            RuleFor(x => x.AmbienteId)
                .IdOpcionalValido("Ambiente")
                .NoExisteIdRelacionAsync(context,
                    async (ctx, id) => await ctx.Set<Ambiente>()
                        .AnyAsync(x => x.AmbienteId == id),
                    "Ambiente");

            RuleFor(x => x.Descripcion)
                .DescripcionValidaOpcional("Descripcion", 500);

            RuleFor(x => x.UsuarioResponsable)
                .MaximumLength(200);

            RuleFor(x => x.Dominio)
                .MaximumLength(200);

            RuleFor(x => x.AplicacionNombre)
                .MaximumLength(200);

            RuleFor(x => x.Adapter)
                .MaximumLength(200);

            RuleFor(x => x.AmbientesQa)
                .MaximumLength(500);

            RuleFor(x => x.GruposRed)
                .MaximumLength(500);

            RuleFor(x => x.Agrupacion)
                .MaximumLength(200);

            RuleFor(x => x.Observacion)
                .MaximumLength(1000);

            RuleFor(x => x.Ip)
                .Must(ip => string.IsNullOrWhiteSpace(ip) ||
                            System.Net.IPAddress.TryParse(ip, out _))
                .WithMessage("La IP no es válida");

            RuleFor(x => x.DiscoHddGb)
                .GreaterThan(0).When(x => x.DiscoHddGb.HasValue);

            RuleFor(x => x.MemoriaGb)
                .GreaterThan(0).When(x => x.MemoriaGb.HasValue);

            RuleFor(x => x.MemoriaActualGb)
                .GreaterThanOrEqualTo(0).When(x => x.MemoriaActualGb.HasValue);

            RuleFor(x => x.EspacioDiscoGb)
                .GreaterThan(0).When(x => x.EspacioDiscoGb.HasValue);

            RuleFor(x => x.EspacioActualDiscoGb)
                .GreaterThanOrEqualTo(0).When(x => x.EspacioActualDiscoGb.HasValue);

            RuleFor(x => x.CantidadScores)
                .GreaterThanOrEqualTo(0).When(x => x.CantidadScores.HasValue);

            RuleFor(x => x.Sockets)
                .GreaterThan(0).When(x => x.Sockets.HasValue);

            RuleFor(x => x.FechaApagado)
                .GreaterThan(x => x.FechaResponsabilidad.Value)
                .When(x => x.FechaApagado.HasValue && x.FechaResponsabilidad.HasValue)
                .WithMessage("La fecha de apagado debe ser mayor a la fecha de responsabilidad");

            RuleFor(x => x.FechaDecomision)
                .GreaterThan(x => x.FechaApagado.Value)
                .When(x => x.FechaDecomision.HasValue && x.FechaApagado.HasValue)
                .WithMessage("La fecha de decomisión debe ser mayor a la fecha de apagado");
        }
    }
}
