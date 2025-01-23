using ExchangeRate.Domain.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IHasDate
    {
        private readonly ExchangeRateDbContext _dbContext;
        public GenericRepository(ExchangeRateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> Get(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.Set<T>()
            .Where(x => EF.Property<DateTime>(x, "Date") >= startDate && EF.Property<DateTime>(x, "Date") <= endDate)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
