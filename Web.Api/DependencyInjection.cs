using Application.Services;
using Domain.Interfaces;
using Domain.Validators;
using FluentValidation;
using Infrastructure.Repositories;

namespace Web.Api;
    
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization();
        services.AddControllers();

        return services;
    } 
}
