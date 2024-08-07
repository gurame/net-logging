
using System.Text.Json;
using ConsoleApp;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder=>{
	builder.SetMinimumLevel(LogLevel.Debug);
	builder.AddJsonConsole(x=>{
		x.IncludeScopes = true;
		x.TimestampFormat = "HH:mm:ss";
		x.JsonWriterOptions = new JsonWriterOptions
		{
			Indented = true
		};
	});

	//builder.ClearProviders();
	//builder.AddSimpleConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();

var name = "Gustavo";
var age = 30;

logger.LogTrace("Hello from Trace, {Name}! You are {Age} years old.", name, age);

try
{
	logger.LogDebug(LogEvents.UserBirthday, "Hello from Debug, {Name}! You are {Age} years old.", name, age);
	throw new Exception("Something went wrong!");
}
catch (Exception ex)
{
	logger.LogError(ex, "Hello from Error, {Name}! You are {Age} years old.", name, age);
}


var paymentId = 1;
var amount = 17.99;
var date = DateTime.Now;

using(logger.BeginTimedOperation("Handling payment {PaymentId}", paymentId))
{
	logger.LogInformation("Processing payment with amount {Amount:C} at {Date}.", amount, date);
}

// Scopes
using (logger.BeginScope("Payment {PaymentId}", paymentId))
{
	try
	{
		logger.LogInformation("Processing payment with amount {Amount:C} at {Date}.", amount, date);
	}
	finally
	{
		logger.LogInformation("Payment {PaymentId} processed.", paymentId);	
	}
}

// box is happening here with args, converting value types to reference types

/*
var paymentData = new PaymentData
{
	PaymentId = 2,
	Amount = 19.99m,
	Date = DateTime.Now
};

logger.LogInformation("Payment with data: {paymentData}.", paymentData);

class PaymentData
{
	public int PaymentId { get; set; }
	public decimal Amount { get; set; }
	public DateTime Date { get; set; }
}
*/