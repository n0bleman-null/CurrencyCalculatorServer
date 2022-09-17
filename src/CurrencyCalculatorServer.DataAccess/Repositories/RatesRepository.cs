using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CurrencyCalculatorServer.DataAccess.Repositories
{
    /// <summary>
    /// Rates repository
    /// </summary>
    /// <seealso cref="CurrencyCalculatorServer.Business.Repositories.IRatesRepository" />
    public class RatesRepository : IRatesRepository
    {
        private readonly DbSet<Rate> _rates;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatesRepository"/> class.
        /// </summary>
        /// <param name="rates">The rates.</param>
        public RatesRepository(DbSet<Rate> rates)
        {
            _rates = rates;
        }

        /// <summary>
        /// Adds the or insert range of rates.
        /// </summary>
        /// <param name="rates"></param>
        /// <param name="token">The token.</param>
        public async Task InsertOrUpdateRange(IEnumerable<Rate> rates, CancellationToken token)
        {
            foreach (var rate in rates)
            {
                var existing = await _rates.FirstOrDefaultAsync(e => e.CurrencyId == rate.CurrencyId && e.Date == rate.Date);

                if (existing is null)
                {
                    _rates.Add(rate);
                }
                else
                {
                    existing.Price = rate.Price;
                    existing.Date = rate.Date;
                    existing.Type = existing.Type;
                    _rates.Update(existing);
                }
            }
        }
    }
}
