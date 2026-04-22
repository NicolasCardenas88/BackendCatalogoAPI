using FluentValidation;
using Microsoft.EntityFrameworkCore;
namespace BackendCatalogoAXA.Logic.Validator.Common
{
    public static class ValidationExtension
    {
        public static IRuleBuilderOptions<T, string> CodigoValido<T>(this IRuleBuilder<T, string?> ruleBuilder,
            int maxLength )
        {
            return ruleBuilder
                .NotEmpty().WithMessage("El código no puede estar vacío.")
                .MaximumLength(maxLength).WithMessage($"El código no puede tener más de {maxLength} caracteres.");
        }

        public static IRuleBuilderOptions<T, string> NombreValido<T>(this IRuleBuilder<T, string?> ruleBuilder,
                int maxLength)
        {
                return ruleBuilder
                    .NotEmpty().WithMessage("El nombre no puede estar vacío.")
                    .MaximumLength(maxLength).WithMessage($"El nombre no puede tener más de {maxLength} caracteres.");
        }

        public static IRuleBuilderOptions<T, string> DescripcionValida<T> (this IRuleBuilder<T, string?> ruleBuilder,
            int maxLength)
        {
            return ruleBuilder
                .NotEmpty().WithMessage($"La descripción no puede estar vacia.")
                .MaximumLength(maxLength).WithMessage($"La descripcion no debe ser mayor a {maxLength} caracteres ");
        }

        public static IRuleBuilderOptions<T, int> IdRelacionValido <T>(this IRuleBuilder<T, int> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .GreaterThan(0).WithMessage($"El id del campo {fieldName} debe ser mayor a 0");
        }
        public static IRuleBuilderOptions<T, int?> IdOpcionalValido<T>(this IRuleBuilder<T, int?> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .GreaterThan(0).WithMessage($"El id del campo {fieldName} debe ser mayor a 0");
        }

        public static IRuleBuilderOptions<T, string> UrlValida <T>(this IRuleBuilder<T, string?> ruleBuilder,
            string nameField,int maxLength)
        {
            return ruleBuilder
                .MaximumLength(maxLength).WithMessage($"La url no debe superar {maxLength} caracteres")
            .Must(url => string.IsNullOrWhiteSpace(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("El campo debe tener una url valida ");
        }

        public static IRuleBuilderOptions<T, string?> DescripcionValidaOpcional <T>(this IRuleBuilder<T, string?> ruleBuilder,
        string nameField, int maxLength)
        {
            return ruleBuilder
                .MaximumLength(maxLength).WithMessage($"La descripcion no debe superar {maxLength} caracteres");
        }

        public static IRuleBuilderOptions<T, string> YaExisteAsync<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            DbContext context,
            Func<DbContext, string, Task<bool>> existsFunc,
            string entityName)
        {
            return ruleBuilder.MustAsync(async (value, cancellation) =>
                !await existsFunc(context, value)
            )
            .WithMessage((obj,value) => $"Ya existe un {entityName} con el valor '{value}'");
        }
        public static IRuleBuilderOptions<T, int> NoExisteIdRelacionAsync<T>(
            this IRuleBuilder<T, int> ruleBuilder,
            DbContext context,
            Func<DbContext, int, Task<bool>> existsFunc,
            string entityName)
        {
            return ruleBuilder.MustAsync(async (value, cancellation) =>
                await existsFunc(context, value)
            )
            .WithMessage((obj, value) => $"No existe un {entityName} con el valor '{value}'");
        }

        public static IRuleBuilderOptions<T, int?> NoExisteIdRelacionAsync<T>(
            this IRuleBuilder<T, int?> ruleBuilder,
            DbContext context,
            Func<DbContext, int, Task<bool>> existsFunc,
            string entityName)
        {
            return ruleBuilder
                .MustAsync(async (value, cancellation) =>
                {
                    if (!value.HasValue) return true; 
                    return await existsFunc(context, value.Value);
                })
                .WithMessage((obj, value) => $"No existe un {entityName} con el valor '{value}'");
        }

    }
}
