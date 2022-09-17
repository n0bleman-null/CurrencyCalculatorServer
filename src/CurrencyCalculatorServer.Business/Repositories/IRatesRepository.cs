using CurrencyCalculatorServer.Business.Models;

namespace CurrencyCalculatorServer.Business.Repositories
{
    /// <summary>
    /// Rates repository
    /// </summary>
    public interface IRatesRepository
    {
        /// <summary>
        /// Adds the or insert range of rates.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        /// <param name="token">The token.</param>
        public Task InsertOrUpdateRange(IEnumerable<Rate> rates, CancellationToken token);
    }
}
