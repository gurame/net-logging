
using HighPerformance.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((context, services) =>
	{
		services.AddTransient<PaymentService>();
	})
	.ConfigureLogging(logging =>
	{
		logging.ClearProviders();
		logging.AddConsole();
	})
	.Build();

var paymentService = host.Services.GetRequiredService<PaymentService>();

paymentService.CreatePayment("gurame@gurame.com", 100m, 10);

