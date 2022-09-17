using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Options;
using CurrencyCalculatorServer.Business.Services;
using CurrencyCalculatorServer.Presentation.Infrastructure.Extensions;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Sockets;

namespace CurrencyCalculatorServer.Presentation.Infrastructure;

/// <summary>
/// Udp service
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Hosting.Server.IServer" />
public class UdpServer : IServer
{
    private readonly UdpClient _listener = new();
    private readonly IPEndPoint _listenEndpoint;
    private readonly IServiceProvider _services;
    private readonly ILogger<UdpServer> _logger;
    public IFeatureCollection Features => new FeatureCollection();

    /// <summary>
    /// Initializes a new instance of the <see cref="UdpServer"/> class.
    /// </summary>
    /// <param name="udpOptions">The UDP options.</param>
    /// <param name="services">The services.</param>
    /// <param name="logger">The logger.</param>
    public UdpServer(
        IOptions<UdpServerOptions> udpOptions,
        IServiceProvider services,
        ILogger<UdpServer> logger)
    {
        ArgumentNullException.ThrowIfNull(udpOptions, nameof(udpOptions));
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        _listenEndpoint = new IPEndPoint(udpOptions.Value.Address, udpOptions.Value.Port);
        _listener = new(_listenEndpoint);
        _services = services;
        _logger = logger;
    }

    /// <summary>
    /// Start the server with an application.
    /// </summary>
    /// <typeparam name="TContext">The context associated with the application.</typeparam>
    /// <param name="application">An instance of <see cref="T:Microsoft.AspNetCore.Hosting.Server.IHttpApplication`1" />.</param>
    /// <param name="cancellationToken">Indicates if the server startup should be aborted.</param>
    public async Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
        where TContext : notnull
    {
        _logger.LogInformation(
            "UDP server starting to listen on: IP address '{address}' Port '{port}'", _listenEndpoint.Address, _listenEndpoint.Port);

        while (!cancellationToken.IsCancellationRequested)
        {
            using (var scope = _services.CreateScope())
            {
                var request = await _listener.ReceiveAsync(cancellationToken).ConfigureAwait(false);

                var model = request.Buffer.FromBytes<GetConversionRatesRequest>();
                var sender = request.RemoteEndPoint;

                var currencyCalculatorService =
                    scope.ServiceProvider
                        .GetRequiredService<ICurrencyCalculatorService>();

                var result = await currencyCalculatorService.ConvertCurrency(model.Quantity,
                    model.CurrencyCode,
                    model.Date,
                    cancellationToken);

                var bytes = result.ToArray().GetBytesArray();

                await _listener.SendAsync(bytes, sender, cancellationToken);
            }
        };
    }

    /// <summary>
    /// Stop processing requests and shut down the server, gracefully if possible.
    /// </summary>
    /// <param name="cancellationToken">Indicates if the graceful shutdown should be aborted.</param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _listener?.Dispose();
    }
}

