using CurrencyCalculatorServer.Business.Fetchers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CurrencyCalculatorServer.IntegrationalTests.Business.Fetchers
{
    public class RatesFetcherIntegrationalTests : IClassFixture<WebAppFactory>, IDisposable
    {
        private static readonly CancellationToken _ct = CancellationToken.None;

        private readonly IServiceScope _scope;

        private readonly IRatesFetcher _ratesFetcher;

        public RatesFetcherIntegrationalTests(WebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _ratesFetcher = _scope.ServiceProvider.GetRequiredService<IRatesFetcher>();
        }

        [Fact]
        public async Task RatesFetcher_Should_FetchDailyRatesForToday()
        {
            // Act
            var actualResult = await _ratesFetcher.GetDailyRatesForToday(_ct);

            // Assert
            actualResult.Should()
                .NotBeNullOrEmpty();
        }

        [Fact]
        public async Task RatesFetcher_Should_FetchMonthlyRatesForThisMonth()
        {
            // Act
            var actualResult = await _ratesFetcher.GetMonthlyRatesForThisMonth(_ct);

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
