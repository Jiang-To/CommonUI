using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;


namespace CommonUI.Server.Extensions {

    public static class SerilogExtensions {
        public static void AddLogger(this IServiceCollection services, AppConfig config) {
            // parse log level from config
            var loggerLevel = LogEventLevel.Information;
            Enum.TryParse(config.Logger.Level, true, out loggerLevel);

            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = loggerLevel;

            var outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{RequestId}] [{Level:u3}] {Message:lj}{NewLine}{Exception}";
            var serilogConfig = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.Console(
                    outputTemplate: outputTemplate
                )
                .WriteTo.File(
                    path: @"logs\.log",
                    outputTemplate: outputTemplate,
                    rollingInterval: RollingInterval.Day
                );

            Log.Logger = serilogConfig.CreateLogger();
            AppDomain.CurrentDomain.DomainUnload += (obj, e) => Log.CloseAndFlush();
            
            services.AddLogging(_config => {
                // clear asp.net core default logger
                _config.ClearProviders();
                // enable Serilog
                _config.AddSerilog();
            });
        }
    }
}