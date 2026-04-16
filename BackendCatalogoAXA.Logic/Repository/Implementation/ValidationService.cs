using FluentValidation;

using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BackendCatalogoAXA.Logic.Repository.Implementation
{
    public class ValidationService (IServiceProvider serviceProvider) : IValidadationService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task ValidateAsync<T>(T dto)
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();
            if (validator is null)
                return;
            await validator.ValidateAndThrowAsync(dto);
        }
    }
}
