
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

using IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureLogging(logging =>
	{
		//logging.AddJsonConsole();
		logging.AddFilter("System", LogLevel.Debug);
		logging.AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Information);
		logging.AddFilter<ConsoleLoggerProvider>("Microsoft.Extensions.Hosting.Internal.Host", LogLevel.Debug);
	})
	.Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Hello, world!");

await host.RunAsync();