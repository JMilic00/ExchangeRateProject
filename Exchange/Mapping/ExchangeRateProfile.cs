using AutoMapper;
using ExchangeRate.Api.Dtos;
using ExchangeRate.Api.Entities;

public class ExchangeRateMappingProfile : Profile
{
    public ExchangeRateMappingProfile()
    {
        // Mapping from ExchangeRateEntity to ExchangeRateDto
        CreateMap<ExchangeRateEntity, ExchangeRateDto>()
           .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
           .ForMember(dest => dest.BuyRate, opt => opt.MapFrom(src => src.BuyRate))
           .ForMember(dest => dest.SellRate, opt => opt.MapFrom(src => src.SellRate))
           .ForMember(dest => dest.MidRate, opt => opt.MapFrom(src => src.MidRate))
           .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));

        // Map from ExchangeRateDto to ExchangeRateEntity (for database storage)
        CreateMap<ExchangeRateDto, ExchangeRateEntity>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.BuyRate, opt => opt.MapFrom(src => src.BuyRate))
            .ForMember(dest => dest.SellRate, opt => opt.MapFrom(src => src.SellRate))
            .ForMember(dest => dest.MidRate, opt => opt.MapFrom(src => src.MidRate))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));

        // Explicitly map List<ExchangeRateDto> to List<ExchangeRateEntity>
        CreateMap<List<ExchangeRateDto>, List<ExchangeRateEntity>>()
            .ConvertUsing((src, dest, context) => src.Select(dto => context.Mapper.Map<ExchangeRateEntity>(dto)).ToList());

        // Explicitly map List<ApiExchangeRateEntity> to List<ExchangeRateDto>
        CreateMap<List<ApiExchangeRateEntity>, List<ExchangeRateDto>>()
            .ConvertUsing((src, dest, context) => src.Select(entity => context.Mapper.Map<ExchangeRateDto>(entity)).ToList());
    }
}