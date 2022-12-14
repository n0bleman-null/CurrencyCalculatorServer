using CurrencyCalculatorServer.Business.Services;

namespace CurrencyCalculatorServer.Presentation.Infrastructure.BackgroundServices
{
    /// <summary>
    /// Fetches daily rates for every hour
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Hosting.BackgroundService" />
    public class RatesDailyFetchingBackgroundServices : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<RatesDailyFetchingBackgroundServices> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatesDailyFetchingBackgroundServices"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="logger">The logger.</param>
        public RatesDailyFetchingBackgroundServices(IServiceProvider services,
            ILogger<RatesDailyFetchingBackgroundServices> logger)
        {
            _services = services;
            _logger = logger;
        }

        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" /> starts. The implementation should return a task that represents
        /// the lifetime of the long running operation(s) being performed.
        /// </summary>
        /// <param name="stoppingToken">Triggered when <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" /> is called.</param>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var rateUpdatingService =
                        scope.ServiceProvider
                            .GetRequiredService<IRateUpdatingService>();

                    await rateUpdatingService.UpdateDailyRates(stoppingToken);
                }

                _logger.LogDebug("Fetched daily data");

                await Task.Delay(TimeSpan.FromHours(1));
            }
        }
    }
}
