using ExchangeRate.Api.Data;
using ExchangeRate.Api.Endpoints;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Database connection string from configuration
        var connString = builder.Configuration.GetConnectionString("ExchangeRateConnection");
        builder.Services.AddControllers();

        // Add services to the container
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSqlServer<ExchangeRateContext>(connString);
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<ExchangeRateService>();

        // Add AutoMapper
        builder.Services.AddAutoMapper(typeof(ExchangeRateMappingProfile));

        var app = builder.Build();

        // Set up the endpoints
        app.MapExchangeRatesEndpoints();

        // Configure the HTTP request pipeline
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