using CurrencyCalculatorServer.Business.Fetchers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CurrencyCalculatorServer.IntegrationalTests.Business.Fetchers
{
    public class CurrenciesFetcherIntegrationalTests : IClassFixture<WebAppFactory>, IDisposable
    {
        private static readonly CancellationToken _ct = CancellationToken.None;

        private readonly IServiceScope _scope;

        private readonly ICurrenciesFetcher _currenciesFetcher;

        public CurrenciesFetcherIntegrationalTests(WebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _currenciesFetcher = _scope.ServiceProvider.GetRequiredService<ICurrenciesFetcher>();
        }

        [Fact]
        public async Task CurrenciesFetcher_Should_FetchAllCurrencies()
        {
            // Act
            var actualResult = await _currenciesFetcher.GetAllCurrencies(_ct);

            // Assert
            actualResult.Should()
                .NotBeNullOrEmpty();
        }

        [Fact]
        public async Task CurrenciesFetcher_Should_FetchTargerCurrency()
        {
            // Arrange
            int currencyID = 431;

            // Act
            var actualResult = await _currenciesFetcher.GetCurrency(currencyID, _ct);

            // Assert
            actualResult.Should()
                .NotBeNull();
            actualResult.Cur_Abbreviation.Should()
                .Be("USD");
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
