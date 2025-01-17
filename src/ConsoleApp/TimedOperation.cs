using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace ConsoleApp;

public class TimedOperation : IDisposable
{
	private readonly ILogger _logger;
	private readonly LogLevel _logLevel;
	private readonly string _messageTemplate;
	private readonly object[] _args;
	private readonly long _startingTimeStamp;
    public TimedOperation(ILogger logger, LogLevel logLevel, string messageTemplate, object[] args)
    {
        _logger = logger;
        _logLevel = logLevel;
        _messageTemplate = messageTemplate;
        _args = new object[args.Length + 1];
        Array.Copy(args, _args, args.Length);
        _startingTimeStamp = Stopwatch.GetTimestamp();
    }
    public void Dispose()
    {
        var delta = Stopwatch.GetElapsedTime(_startingTimeStamp);
		_args[^1] = delta.TotalMilliseconds;
		_logger.Log(_logLevel, $"{_messageTemplate} completed in {{OperationDurationMs}}ms", _args);
    }
}
