using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NetStockAssignment.CsvHelper.Services;

namespace NetStockAssignment.Services
{
    internal sealed class ConsoleHostedService : IHostedService
    {
        private int? _exitCode;

        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IDearService _dearService;

		public ConsoleHostedService(
            IServiceScopeFactory scopeFactory,
            ILogger<ConsoleHostedService> logger,
            IHostApplicationLifetime appLifetime,
            IDearService dearService
			)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
            _appLifetime = appLifetime;
            _dearService = dearService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");

            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        _logger.LogInformation("Starting the process...");

                        bool result = await _dearService.DoWork();

                        _logger.LogInformation($"Result is: {result}");

                        _exitCode = 0;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception");
                        _exitCode = 1;
                    }
                    finally
                    {
                        _logger.LogInformation("Sync completed.");
                        _appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Exiting with return code: {_exitCode}");

            // Exit code may be null if the user cancelled via Ctrl+C/SIGTERM
            Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
            return Task.CompletedTask;
        }
    }
}
