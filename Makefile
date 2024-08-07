build:
	dotnet build Logging.sln

run-consoleapp:
	dotnet run --project src/ConsoleApp/ConsoleApp.csproj

run-host-consoleapp:
	dotnet run --project src/HostConsoleApp/HostConsoleApp.csproj

run-minimalapi:
	dotnet run --project src/MinimalApi/MinimalApi.csproj

run-serilog-consoleapp:
	dotnet run --project src/WithSerilog.ConsoleApp/WithSerilog.ConsoleApp.csproj

run-serilog-minimalapi:
	dotnet run --project src/WithSerilog.MinimalApi/WithSerilog.MinimalApi.csproj

run-hp-consoleapp:
	dotnet run --project src/HighPerformance.ConsoleApp/HighPerformance.ConsoleApp.csproj