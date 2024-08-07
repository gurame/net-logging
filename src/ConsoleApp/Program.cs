
using ConsoleApp;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder=>{
	builder.SetMinimumLevel(LogLevel.Debug);
	builder.AddJsonConsole(x=>{
		x.IncludeScopes = false;
		x.TimestampFormat = "HH:mm:ss";
		x.JsonWriterOptions = new System.Text.Json.JsonWriterOptions
		{
			Indented = true
		};
	});

	builder.ClearProviders();
	builder.AddSimpleConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();

var name = "Gustavo";
var age = 30;

logger.LogTrace("Hello from Trace, {Name}! You are {Age} years old.", name, age);
logger.LogDebug(LogEvents.UserBirthday, "Hello from Debug, {Name}! You are {Age} years old.", name, age);