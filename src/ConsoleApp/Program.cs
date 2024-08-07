
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder=>{
	builder.SetMinimumLevel(LogLevel.Debug);
	builder.AddJsonConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();

var name = "Gustavo";
var age = 30;

logger.LogTrace("Hello from Trace, {Name}! You are {Age} years old.", name, age);
logger.LogDebug("Hello from Debug, {Name}! You are {Age} years old.", name, age);