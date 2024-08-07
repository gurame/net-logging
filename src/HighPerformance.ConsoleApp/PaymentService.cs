using Microsoft.Extensions.Logging;

namespace HighPerformance.ConsoleApp;

public class PaymentService
{
	private readonly ILogger<PaymentService> _logger;
	private static readonly Action<ILogger, string, decimal, int, Exception> _createPayment = 
		LoggerMessage.Define<string, decimal, int>(
			LogLevel.Information,
			new EventId(1, nameof(CreatePayment)),
			"Creating payment for {Email} with amount {Amount} for product {ProductId}");


    public PaymentService(ILogger<PaymentService> logger)
    {
        _logger = logger;
    }

	public void CreatePayment(string email, decimal amount, int productId)
	{
		//_logger.LogInformation("Creating payment for {Email} with amount {Amount} for product {ProductId}", email, amount, productId);
		_createPayment(_logger, email, amount, productId, null);
	}
}
