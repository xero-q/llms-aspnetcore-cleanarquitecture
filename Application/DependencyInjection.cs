using Application.Services;
using Application.Abstractions.Services;
using Domain.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
   
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IModelTypeService, ModelTypeService>();
        services.AddScoped<IModelService, ModelService>();
        services.AddScoped<IThreadService, ThreadService>();
        services.AddValidatorsFromAssemblyContaining<UserValidator>();
        
        return services;
    } 
}