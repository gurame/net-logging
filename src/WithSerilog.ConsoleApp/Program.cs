
using Destructurama;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.SystemConsole.Themes;
using SerilogTimings.Extensions;
using WithSerilog.ConsoleApp;

ILogger logger = new LoggerConfiguration()
	//.WriteTo.Console(theme: AnsiConsoleTheme.Code)
	//.WriteTo.Console(new JsonFormatter())
	.WriteTo.Sink<GurameSink>()
	.Enrich.FromLogContext()
	//.Destructure.ByTransforming<Payment>(p => new { p.PaymentId, p.UserId })
	.Destructure.UsingAttributes()
	.CreateLogger();

Log.Logger = logger;

var payment = new Payment
{
	PaymentId = 1,
	Email = "test@test.com",
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

using(logger.TimeOperation("Processing payment {PaymentId}", payment.PaymentId))
{
	Thread.Sleep(1000);
	logger.Information("Received payment by user with id {UserId}", payment.UserId);
}

Log.CloseAndFlush();