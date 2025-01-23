﻿using AutoMapper;
using ExchangeRate.Domain.Contracts.Persistance;
using ExchangeRate.Domain.Dtos.ExchangeRateDto;
using ExchangeRate.Domain.Features.ExchngeRates.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.Features.ExchngeRates.Handlers.Queries
{
    public class GetExchangeRateRequestHandler : IRequestHandler<GetExchangeRateRequest, List<ExchangeRateDto>>
    {
        IExchangeRateRepository _exchangeRateEntityRepository;
        IMapper _mapper;
        public GetExchangeRateRequestHandler(IExchangeRateRepository exchangeRateEntityRepository, IMapper mapper)
        {
            _exchangeRateEntityRepository = exchangeRateEntityRepository;
            _mapper = mapper;
        }
        public async Task<List<ExchangeRateDto>> Handle(GetExchangeRateRequest request, CancellationToken cancellationToken)
        {
            var ExchangeRates = await _exchangeRateEntityRepository.GetAll();
            return _mapper.Map<List<ExchangeRateDto>>(ExchangeRates);
        }
    }
}