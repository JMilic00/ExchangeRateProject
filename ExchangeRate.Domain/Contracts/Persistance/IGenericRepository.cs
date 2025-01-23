using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.Contracts.Persistance
{
    public interface IGenericRepository<T> where T : class, IHasDate
    {
        Task<IReadOnlyList<T>> Get(DateTime StartDate, DateTime EndDate);

        Task<IReadOnlyList<T>> GetAll();

        Task<T> Add(T entity);
    }
}
