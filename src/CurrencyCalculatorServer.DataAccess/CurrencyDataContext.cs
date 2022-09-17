using CurrencyCalculatorServer.Business;
using Microsoft.Extensions.Logging;

namespace CurrencyCalculatorServer.DataAccess
{
    /// <summary>
    /// Currency Data Context
    /// </summary>
    /// <seealso cref="IDataContext" />
    public class CurrencyDataContext : IDataContext
    {
        private readonly CurrencyDbContext _context;
        private readonly ILogger<CurrencyDataContext> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyDataContext"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public CurrencyDataContext(CurrencyDbContext context,
            ILogger<CurrencyDataContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Saves the context changes.
        /// </summary>
        /// <param name="token">A <see cref="T:System.Threading.CancellationToken">CancellationToken</see> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous save operation.
        /// </returns>
        public Task SaveChanges(CancellationToken token)
        {
            return _context.SaveChangesAsync(token);
        }
    }
}
