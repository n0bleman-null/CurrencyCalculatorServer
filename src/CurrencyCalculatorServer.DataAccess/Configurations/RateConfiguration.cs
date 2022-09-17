using CurrencyCalculatorServer.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyCalculatorServer.DataAccess.Configurations
{
    /// <summary>
    /// Rate configuration
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration&lt;CurrencyCalculatorServer.Business.Models.Rate&gt;" />
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Date).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.CurrencyId).IsRequired();

            builder.HasOne(x => x.Currency)
                .WithMany(x => x.Rates)
                .HasForeignKey(x => x.CurrencyId);

            builder.HasIndex(x => new { x.CurrencyId, x.Date }).IsUnique(true);

            builder.ToTable("Rates");
        }
    }
}
