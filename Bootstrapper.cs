
using Azure.Identity;
using NetStockAssignment.Configuration;
using NetStockAssignment.CsvHelper.Services;
using NetStockAssignment.Services;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace NetStockAssignment
{
    public static class Bootstrapper
    {
        public static IHostBuilder AddLogging(this IHostBuilder host)
        {
            host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
            return host;
        }

        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            // configure this in:
            // 1) Project >  Properties > Debug > Environment variables > Name: DOTNET_ENVIRONMENT, Value: Development
            // 2) dotnet NetStockAssignment.dll --environment=Development
            // 3) launchSettings.json
            // context.HostingEnvironment.IsDevelopment() requires an environment called "Development"

            string environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

            host.ConfigureAppConfiguration((_, configuration) =>
            {
                configuration.Sources.Clear();

				configuration
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", optional: false)
					.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
                    //.AddUserSecrets<Program>(true); // remember to create a usersecret on your computer
            });
            return host;
        }

        public static IHostBuilder AddKeyVault(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration((context, configuration) =>
            {
                // Azure Key-Vault can be enabled only in production.
                // In this demo with this setup, we can use also with a development computer 
                //if (!context.HostingEnvironment.IsProduction())
                //{
                //    return;
                //}

                var builtConfig = configuration.Build();
                var keyVaultUri = builtConfig["KeyVaultUri"];

                if (string.IsNullOrEmpty(keyVaultUri))
                {
                    return;
                }

                var keyVaultClient = new KeyVaultClient(
                    async (authority, resource, scope) =>
                    {
                        var credential = new DefaultAzureCredential(false);
                        var token = await credential.GetTokenAsync(
                            new Azure.Core.TokenRequestContext(
                                new[] { "https://vault.azure.net/.default" }
                            )
                        );
                        return token.Token;
                    });

                configuration.AddAzureKeyVault(
                    keyVaultUri,
                    keyVaultClient,
                    new DefaultKeyVaultSecretManager()
                );
            });
            return host;
        }

        /// <summary>
        /// Just for debugging the configuration tree in this demo, do not use in production, neither expose publicly
        /// </summary>
        public static IHostBuilder DumpConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration((context, configuration) =>
            {
                if (context.HostingEnvironment.IsDevelopment())
                {
                    var configTree = configuration.Build().GetDebugView();
                    Console.Write(configTree);
                }
            });

            return host;
        }

        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices((hostingContext, services) =>
            {
                var configurationRoot = hostingContext.Configuration;

                // IHttpClientFactory is very flexible and can be configured in many ways
                services.AddHttpClient();

                // the hosted service (a singleton) that wrap the console logic that allows DI
                services.AddHostedService<ConsoleHostedService>();

                // you can provide the instrumentation key as:
                // 1) an argument to AddApplicationInsightsTelemetryWorkerService,
                // 2) in configuration in appsettings.json
                //services.AddApplicationInsightsTelemetryWorkerService();

                // transient services with your business logic
                // if you need a different lifescope, you can use inject a IServiceScopeFactory and
                // create a scope (as example to consume EF contexts)
                services.AddTransient<IDearService, DearService>();
				services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

				// Option object that can be injected in any service. Use a class for each logical group.
				services.Configure<DearOptions>(configurationRoot.GetSection(key: nameof(DearOptions)));
                services.Configure<ExtraOptions>(configurationRoot.GetSection(key: nameof(ExtraOptions)));
            });
            return host;
        }
    }
}
