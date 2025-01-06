﻿using AutoMapper;
using ExchangeRate.Api.Data;
using ExchangeRate.Api.Dtos;
using ExchangeRate.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ExchangeRate.Api.Services
{
    public class ExchangeRateService
    {
        private readonly ExchangeRateContext _dbContext;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ExchangeRateService(ExchangeRateContext dbContext, HttpClient httpClient, IMapper mapper)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
            _mapper = mapper;
        }

        // Fetch and store exchange rates from the API
        public async Task FetchAndStoreExchangeRates(DateTime startDate, DateTime endDate)
        {
            var url = $"https://api.hnb.hr/tecajn-eur/v3?datum-primjene-od={startDate:yyyy-MM-dd}&datum-primjene-do={endDate:yyyy-MM-dd}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching data from API. Status Code: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("API Response: " + content);  // Log the raw JSON

            try
            {
                var apiExchangeRates = JsonSerializer.Deserialize<List<ApiExchangeRateEntity>>(content);

                if (apiExchangeRates == null || !apiExchangeRates.Any())
                {
                    throw new Exception("No exchange rates found in response.");
                }

                var exchangeRateDtos = _mapper.Map<List<ExchangeRateDto>>(apiExchangeRates);
                var entities = _mapper.Map<List<ExchangeRateEntity>>(exchangeRateDtos);

                _dbContext.ExchangeRates.AddRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (JsonException ex)
            {
                throw new Exception("Failed to deserialize exchange rate data.", ex);
            }
        }

        // Get exchange rates from the database for a date range
        public async Task<List<ExchangeRateDto>> GetExchangeRatesAsync(DateTime startDate, DateTime endDate)
        {
            var entities = await _dbContext.ExchangeRates
                .Where(e => e.Date >= startDate && e.Date <= endDate)
                .ToListAsync();

            // Map the data to the new DTO directly
            return _mapper.Map<List<ExchangeRateDto>>(entities);
        }
    }
}