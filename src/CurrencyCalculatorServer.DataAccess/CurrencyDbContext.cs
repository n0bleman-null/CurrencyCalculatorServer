using Microsoft.EntityFrameworkCore;

namespace CurrencyCalculatorServer.DataAccess
{
    /// <summary>
    /// Currency database context
    /// </summary>
    /// <seealso cref="DbContext" />
    public class CurrencyDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyDbContext" /> class.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public CurrencyDbContext(DbContextOptions<CurrencyDbContext> options)
            : base(options) { }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1">DbSet</see> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)">UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)</see>)
        /// then this method will not be run.
        /// </para>
        /// <para>
        /// See <a href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</a> for more information.
        /// </para>
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrencyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
