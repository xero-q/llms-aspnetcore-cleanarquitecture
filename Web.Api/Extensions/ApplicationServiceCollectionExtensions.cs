using Application.Services;
using Domain.Interfaces;
using Domain.Validators;
using FluentValidation;
using Infrastructure.Repositories;
using Infrastucture.Repositories;
using LLMStudio;

namespace Web.Api.Extensions;
    
public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IModelTypeRepository, ModelTypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddValidatorsFromAssemblyContaining<ModelTypeValidator>();
        services.AddValidatorsFromAssemblyContaining<ModelValidator>();
        services.AddValidatorsFromAssemblyContaining<UserValidator>();
        
        return services;
    } 
}
