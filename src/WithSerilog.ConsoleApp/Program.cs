
using Serilog;
using Serilog.Context;
using Serilog.Formatting.Json;
using Serilog.Sinks.SystemConsole.Themes;

ILogger logger = new LoggerConfiguration()
	//.WriteTo.Console(theme: AnsiConsoleTheme.Code)
	.WriteTo.Console(new JsonFormatter())
	.Enrich.FromLogContext()
	.Destructure.ByTransforming<Payment>(p => new { p.PaymentId, p.UserId })
	.CreateLogger();

Log.Logger = logger;

var payment = new Payment
{
	PaymentId = 1,
	UserId = Guid.NewGuid(),
	OccuredAt = DateTime.UtcNow
};

var paymentData = new Dictionary<string, object>
{
	{ "PaymentId", payment.PaymentId },
	{ "UserId", payment.UserId },
	{ "OccuredAt", payment.OccuredAt }
};

logger.Information("Payment processed {@Payment}", payment);

using(LogContext.PushProperty("PaymentId", payment.PaymentId))
{
	logger.Information("User {UserId} processed payment", payment.UserId);
}

Log.CloseAndFlush();