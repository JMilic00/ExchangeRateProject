using AutoMapper;
using ExchangeRate.Domain.Contracts.Persistance;
using ExchangeRate.Domain.Dtos.ExchangeRateDto;
using ExchangeRate.Domain.Features.ExchngeRates.Requests.Commands;
using ExchangeRate.Domain.Features.ExchngeRates.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.Features.ExchngeRates.Handlers.Commands
{
    public class CreateExchangeRateCommandHandler : IRequestHandler<CreateExchangeRateCommand, int>
    {
        IExchangeRateRepository _exchangeRateEntityRepository;
        IMapper _mapper;
        HttpClient _httpClient;

        public CreateExchangeRateCommandHandler(IExchangeRateRepository exchangeRateEntityRepository, IMapper mapper, HttpClient httpClient)
        {
            _exchangeRateEntityRepository = exchangeRateEntityRepository;
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public async Task<int> Handle(CreateExchangeRateCommand request, CancellationToken cancellationToken)
        {
            if (request.ExchangeRateDto == null)
                throw new ArgumentException("Exchange rate data is required.");

            var startDate = request.ExchangeRateDto.StartDate;
            var endDate = request.ExchangeRateDto.EndDate;

            if (startDate >= endDate)
                throw new ArgumentException("StartDate must be earlier than EndDate.");

            // Step 2: Call the external API
            var apiUrl = $"https://api.hnb.hr/tecajn-eur/v3?datum-primjene-od={startDate:yyyy-MM-dd}&datum-primjene-do={endDate:yyyy-MM-dd}";
            var response = await _httpClient.GetAsync(apiUrl, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Failed to fetch data from the API. Status code: {response.StatusCode}");

            var apiResponseContent = await response.Content.ReadAsStringAsync();
            //var exchangeRateEntities = JsonSerializer.Deserialize<List<ExchangeRateEntity>>(apiResponseContent);

            var exchangeRateEntities = JsonSerializer.Deserialize<List<ExchangeRateEntity>>(apiResponseContent);


            foreach (var entity in exchangeRateEntities)
            {
                if (string.IsNullOrEmpty(entity.BrojTecajnice))
                {
                    entity.BrojTecajnice = "DefaultValue"; // Provide a default value if needed
                }

                await _exchangeRateEntityRepository.Add(entity);
            }

            // Return the number of records created
            return exchangeRateEntities.Count;

        }

    }
}
