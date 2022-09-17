using CurrencyCalculatorServer.Presentation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CurrencyCalculatorServer.IntegrationalTests
{
    public class WebAppFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //builder.UseSetting("Environment", "IntegrationTest");
            base.ConfigureWebHost(builder);
        }
    }
}
