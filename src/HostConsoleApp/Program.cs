
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureLogging(logging =>
	{
		logging.AddJsonConsole();
	})
	.Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Hello, world!");

await host.RunAsync();