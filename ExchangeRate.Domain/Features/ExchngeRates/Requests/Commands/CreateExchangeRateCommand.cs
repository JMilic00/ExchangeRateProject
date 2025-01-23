using ExchangeRate.Domain.Dtos.ExchangeRateDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.Features.ExchngeRates.Requests.Commands
{
    public class CreateExchangeRateCommand : IRequest<int>
    {
        public CreateExchangeRateDto ExchangeRateDto { get; set; }
    }
}
