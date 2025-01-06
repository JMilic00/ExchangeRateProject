﻿using AutoMapper;
using ExchangeRate.Api.Dtos;
using ExchangeRate.Api.Entities;

public class ExchangeRateMappingProfile : Profile
{
    public ExchangeRateMappingProfile()
    {
        // Mapping for GET
        CreateMap<ExchangeRateEntity, ExchangeRateDto>();
        CreateMap<ApiExchangeRateEntity, ExchangeRateDto>();

        // Mapping for POST
        CreateMap<ExchangeRateDto, ExchangeRateEntity>();
        CreateMap<ExchangeRateDto, ApiExchangeRateEntity>();

        // Explicit List Mappings (for both GET and POST)
        CreateMap<List<ExchangeRateDto>, List<ExchangeRateEntity>>()
            .ConvertUsing((src, dest, context) => src.Select(dto => context.Mapper.Map<ExchangeRateEntity>(dto)).ToList());
        CreateMap<List<ExchangeRateDto>, List<ApiExchangeRateEntity>>()
            .ConvertUsing((src, dest, context) => src.Select(dto => context.Mapper.Map<ApiExchangeRateEntity>(dto)).ToList());
        CreateMap<List<ApiExchangeRateEntity>, List<ExchangeRateDto>>()
            .ConvertUsing((src, dest, context) => src.Select(entity => context.Mapper.Map<ExchangeRateDto>(entity)).ToList());
    }
}