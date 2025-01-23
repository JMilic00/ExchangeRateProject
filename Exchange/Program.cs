using ExchangeRate.Domain;
using ExchangeRate.Infrastructure;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.ConfigureInfrastructureServices(builder.Configuration);
        builder.Services.ConfigureDomainServices();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpClient();


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "HR Leave Management API",
                Version = "v1"
            });
        });


        var app = builder.Build();

 
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}