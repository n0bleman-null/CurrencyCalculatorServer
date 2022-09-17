using CurrencyCalculatorServer.Business.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CurrencyCalculatorServer.IntegrationalTests.Business.Services
{
    public class CurrencyCalculatorServiceIntegrationalTests : IClassFixture<WebAppFactory>, IDisposable
    {
        private static readonly CancellationToken _ct = CancellationToken.None;

        private readonly IServiceScope _scope;

        private readonly ICurrencyCalculatorService _currencyCalculatorService;

        public CurrencyCalculatorServiceIntegrationalTests(WebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _currencyCalculatorService = _scope.ServiceProvider.GetRequiredService<ICurrencyCalculatorService>();
        }

        [Fact]
        public async Task CurrencyCalculatorService_()
        {
            // Arrange
            var quantity = 2000.0;
            var currency = "USD";
            var today = DateTime.Today;

            // Act
            var actualResult = await _currencyCalculatorService.ConvertCurrency(
                quantity, currency, today, _ct);

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
