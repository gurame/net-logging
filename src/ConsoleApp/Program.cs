
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder=>{
	builder.AddJsonConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();

var name = "Gustavo";
var age = 30;

logger.LogInformation("Hello, {Name}! You are {Age} years old.", name, age);