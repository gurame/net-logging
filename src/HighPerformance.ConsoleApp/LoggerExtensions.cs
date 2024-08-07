using System;
using Microsoft.Extensions.Logging;

namespace HighPerformance.ConsoleApp;

public static partial class LoggerExtensions
{
	[LoggerMessage(EventId = 1, 
		Level = LogLevel.Information, Message = "Creating payment for {Email} with amount {Amount} for product {ProductId}")]
	public static partial void LogPaymentCreation(this ILogger logger, string email, decimal amount, int productId);
}
