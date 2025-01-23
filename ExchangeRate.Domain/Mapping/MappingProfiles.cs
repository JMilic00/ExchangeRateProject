
using AutoMapper;
using ExchangeRate.Domain.Dtos.ExchangeRateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.Mapping
{
    public class MappingProfiles : Profile
    {
       public MappingProfiles() 
       { 
            CreateMap<ExchangeRateEntity, ExchangeRateDto>().ReverseMap();
        } 
    }
}
