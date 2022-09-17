using CurrencyCalculatorServer.Business.Options;
using Microsoft.AspNetCore.Hosting.Server;

namespace CurrencyCalculatorServer.Presentation.Infrastructure.Extensions
{
    public static class UdpServerExtensions
    {
        /// <summary>
        /// Uses the UDP server.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static IWebHostBuilder UseUdpServer(this IWebHostBuilder builder)
        {
            builder.ConfigureServices(sc =>
            {
                sc.AddSingleton<IServer, UdpServer>();
            });

            return builder;
        }
    }
}
