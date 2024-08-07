using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.MapGet("/", (ILogger<Program> _logger) => {

	_logger.LogInformation("Hello from Minimal Api!");

	return "Hello World!";
});

app.Run();
