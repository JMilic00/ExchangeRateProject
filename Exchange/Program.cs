using ExchangeRate.Api.Data;
using ExchangeRate.Api.Endpoints;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        var connString = builder.Configuration.GetConnectionString("ExchangeRateConnection");
        builder.Services.AddControllers();

       
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSqlServer<ExchangeRateContext>(connString);
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<ExchangeRateService>();

      
        builder.Services.AddAutoMapper(typeof(ExchangeRateMappingProfile));

        var app = builder.Build();

      
        app.MapExchangeRatesEndpoints();

       
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