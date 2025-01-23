using ExchangeRate.Domain.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.Repositories
{
    public class ExchangeRateRepository : GenericRepository<ExchangeRateEntity>, IExchangeRateRepository
    {
        private readonly ExchangeRateDbContext _dbContext;
        public ExchangeRateRepository(ExchangeRateDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
