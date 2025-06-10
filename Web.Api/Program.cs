using Application;
using Infrastructure;
using Web.Api;
using Web.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddPresentation();

DotNetEnv.Env.Load();
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();


// Run migrations here:
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<LLMDbContext>();
//     db.Database.Migrate();
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ValidationMappingMiddleware>();
app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();