using AutoMapper;
using ExchangeRate.Api.Dtos;
using ExchangeRate.Api.Entities;

namespace ExchangeRate.Api.Mapping
{
    public class ExchangeRateMappingProfile : Profile
    {
        public ExchangeRateMappingProfile()
        {
            // Map from ApiExchangeRateEntity to ExchangeRateDto
            CreateMap<ApiExchangeRateEntity, ExchangeRateDto>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)) // Correctly mapped from Date
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
        }
    }
}