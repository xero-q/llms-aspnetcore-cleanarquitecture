namespace Web.Api;
    
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization();
        services.AddControllers();
        
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("http://localhost:4200") // Replace with your frontend URL
                    .AllowAnyHeader()
                    .AllowAnyMethod(); // Allows POST, GET, OPTIONS, etc.
            });
        });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy =>
                policy.RequireClaim("Admin","true"));
        });

        return services;
    } 
}
