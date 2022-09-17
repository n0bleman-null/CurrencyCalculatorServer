using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CurrencyCalculatorServer.DataAccess
{
    /// <summary>
    /// Currency Db Context Factory
    /// </summary>
    /// <seealso cref="IDesignTimeDbContextFactory&lt;CurrencyDbContext&gt;" />
    public class CurrencyDbContextFactory : IDesignTimeDbContextFactory<CurrencyDbContext>
    {
        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>
        /// An instance of <typeparamref name="TContext" />.
        /// </returns>
        public CurrencyDbContext CreateDbContext(string[] args)
        {
            var connection = "Host=localhost;Port=5432;Database=CurrenciesDb;User Id=postgres;Password=1111";
            var optionsBuilder = new DbContextOptionsBuilder<CurrencyDbContext>();

            optionsBuilder.UseNpgsql(connection);

            return new CurrencyDbContext(optionsBuilder.Options);
        }
    }
}
