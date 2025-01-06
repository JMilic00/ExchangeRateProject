using ExchangeRate.Api.Services;

namespace ExchangeRate.Api.Endpoints
{
    public static class ExchangeRatesEndpoints
    {
        public static RouteGroupBuilder MapExchangeRatesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("ExchangeRates");

            // Endpoint to fetch and store exchange rates in the database
            group.MapPost("/populate", async (DateTime startDate, DateTime endDate, ExchangeRateService service) =>
            {
                try
                {
                    await service.FetchAndStoreExchangeRates(startDate, endDate);

                    return Results.Ok("Exchange rates populated successfully.");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest($"Err: {ex.Message}");
                }
            })
            .WithName("PopulateExchangeRates");

            // Endpoint to get exchange rates for a specific date range
            group.MapGet("/", async (DateTime startDate, DateTime endDate, ExchangeRateService service) =>
            {
                try
                {
                    // Fetch exchange rates directly as ExchangeRateDto
                    var rates = await service.GetExchangeRatesAsync(startDate, endDate);

                    // Calculate the average mid exchange rate
                    var averageRate = rates.Any() ? rates.Average(r => r.MidRate) : 0;

                    return Results.Ok(new
                    {
                        Rates = rates,
                        AverageRate = averageRate
                    });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest($"Error: {ex.Message}");
                }
            })
            .WithName("GetExchangeRates");

            return group;
        }
    }
}