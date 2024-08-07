using System;
using Serilog.Core;
using Serilog.Events;

namespace WithSerilog.ConsoleApp;

public class GurameSink : ILogEventSink
{
	private readonly IFormatProvider? _formatProvider;
	public GurameSink()
	{
	}
    public GurameSink(IFormatProvider? formatProvider)
    {
        _formatProvider = formatProvider;
    }

    public void Emit(LogEvent logEvent)
    {
        var message = logEvent.RenderMessage(_formatProvider);

		Console.WriteLine($"GurameSink [{DateTime.UtcNow.ToString("HH:mm:ss")}]: {message}");
    }
}
