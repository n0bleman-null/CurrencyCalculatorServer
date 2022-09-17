using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Providers;
using Microsoft.EntityFrameworkCore;

namespace CurrencyCalculatorServer.DataAccess.Providers
{
    /// <summary>
    /// Rates provider
    /// </summary>
    /// <seealso cref="CurrencyCalculatorServer.Business.Providers.IRatesProvider" />
    public class RatesProvider : IRatesProvider
    {
        private readonly DbSet<Rate> _rates;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatesProvider"/> class.
        /// </summary>
        /// <param name="rates">The rates.</param>
        public RatesProvider(DbSet<Rate> rates)
        {
            _rates = rates;
        }

        /// <summary>
        /// Gets rates by day.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// List of rates
        /// </returns>
        public Task<List<Rate>> GetRatesByDay(DateTime day, CancellationToken token)
        {
            var beginOfMonth = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            return _rates.AsNoTracking().Include(e => e.Currency)
                .Where(e => e.Date.Day == day.Date.Day || (e.Type == RateType.Monthly && e.Date.Day == beginOfMonth.Day))
                .ToListAsync(token);
        }
    }
}
