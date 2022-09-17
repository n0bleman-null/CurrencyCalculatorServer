﻿using Serilog;

namespace CurrencyCalculatorServer.Presentation.Infrastructure.Configurations
{
    public static partial class AppConfigurations
    {
        /// <summary>Adds the serilog logger to service collection.</summary>
        /// <param name="appBuilder">The application builder.</param>
        /// <returns>
        ///   The application builder.
        /// </returns>
        private static WebApplicationBuilder AddSerilogLogger(this WebApplicationBuilder appBuilder)
        {
            appBuilder.Host.UseSerilog((_, serviceProvider, config) =>
            {
                config = config.WriteTo.Console();
                config = appBuilder.Environment.IsDevelopment()
                    ? config.MinimumLevel.Debug()
                    : config.MinimumLevel.Warning();
            });

            return appBuilder;
        }
    }
}
