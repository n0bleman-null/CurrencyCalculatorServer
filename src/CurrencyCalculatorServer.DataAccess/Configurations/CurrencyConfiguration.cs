using CurrencyCalculatorServer.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyCalculatorServer.DataAccess.Configurations
{
    /// <summary>
    /// Currency configuration
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration&lt;CurrencyCalculatorServer.Business.Models.Currency&gt;" />
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Code).IsRequired();

            builder.Property(x => x.Abbreviation).IsRequired();

            builder.Property(x => x.DateStart).IsRequired();

            builder.Property(x => x.DateEnd).IsRequired();

            builder.ToTable("Currencies");
        }
    }
}
