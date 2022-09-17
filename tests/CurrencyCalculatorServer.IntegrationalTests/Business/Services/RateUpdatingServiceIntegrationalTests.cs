using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Providers;
using CurrencyCalculatorServer.Business.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CurrencyCalculatorServer.IntegrationalTests.Business.Services
{
    public class RateUpdatingServiceIntegrationalTests : IClassFixture<WebAppFactory>, IDisposable
    {
        private static readonly CancellationToken _ct = CancellationToken.None;

        private readonly IServiceScope _scope;

        private readonly IRateUpdatingService _rateUpdatingService;
        private readonly IRatesProvider _ratesProvider;

        public RateUpdatingServiceIntegrationalTests(WebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _rateUpdatingService = _scope.ServiceProvider.GetRequiredService<IRateUpdatingService>();
            _ratesProvider = _scope.ServiceProvider.GetRequiredService<IRatesProvider>();
        }

        [Fact]
        public async Task RateUpdatingService_UpdateDailyRates_Should_FetchValuesAndUpdateDatabase()
        {
            // Act
            await _rateUpdatingService.UpdateDailyRates(_ct);
            var actualResult = await _ratesProvider.GetRatesByDay(DateTime.Today, _ct);
            actualResult = actualResult.Where(e => e.Type == RateType.Daily).ToList();

            // Assert
            actualResult.Should()
                .NotBeNullOrEmpty();
        }

        [Fact]
        public async Task RateUpdatingService_UpdateMonthlyRates_Should_FetchValuesAndUpdateDatabase()
        {
            // Act
            await _rateUpdatingService.UpdateMonthlyRates(_ct);
            var actualResult = await _ratesProvider.GetRatesByDay(DateTime.Today, _ct);
            actualResult = actualResult.Where(e => e.Type == RateType.Monthly).ToList();

            // Assert
            actualResult.Should()
                .NotBeNullOrEmpty();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
