

namespace ExchangeRate.Api.Endpoints
{
    public static class ExchangeRatesEndpoints
    {
        public static RouteGroupBuilder MapExchangeRatesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("ExchangeRates");

            // Endpoint to fetch and store
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

            // Endpoint for fetching all the data
            group.MapGet("/", async (DateTime startDate, DateTime endDate, ExchangeRateService service) =>
            {
                try
                {
                    // Fetching
                    var rates = await service.GetExchangeRatesAsync(startDate, endDate);

                    // Calculating the average
                    var averageRate = rates.Any() ? rates.Average(r => r.MidRate) : 0;

                    return Results.Ok(new
                    {
                        Rates = rates,
                        AverageRate = averageRate
                    });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest($"Err: {ex.Message}");
                }
            })
            .WithName("GetExchangeRates");

            group.MapGet("/averages", async (DateTime startDate, DateTime endDate, ExchangeRateService service) =>
            {
                try
                {
                    var rates = await service.GetExchangeRatesAsync(startDate, endDate);

                    if (!rates.Any())
                    {
                        return Results.Ok("No exchange rates found for the given period.");
                    }

                    // Grouping currency and calculating the average for each
                    var averageRatesByCurrency = rates
                        .GroupBy(r => r.Currency)
                        .Select(g => new
                        {
                            Currency = g.Key,
                            AverageMidRate = g.Average(r => r.MidRate)
                        })
                        .ToList();

                    return Results.Ok(new
                    {
                        StartDate = startDate,
                        EndDate = endDate,
                        AverageRates = averageRatesByCurrency
                    });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest($"Err: {ex.Message}");
                }
            })
            .WithName("GetAverageRatesByCurrency");

            return group;
        }
    }
}