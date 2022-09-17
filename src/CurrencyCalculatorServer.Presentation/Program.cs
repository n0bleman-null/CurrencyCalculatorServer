using CurrencyCalculatorServer.Presentation.Infrastructure.Configurations;
using CurrencyCalculatorServer.Presentation.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args)
    .ConfigureApplication();

builder.WebHost
    .UseUdpServer();

var app = builder.Build();

app.Run();

namespace CurrencyCalculatorServer.Presentation
{
    public partial class Program { }
}
