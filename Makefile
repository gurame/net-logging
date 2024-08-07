build:
	dotnet build Logging.sln

run-consoleapp:
	dotnet run --project src/ConsoleApp/ConsoleApp.csproj

run-host-consoleapp:
	dotnet run --project src/HostConsoleApp/HostConsoleApp.csproj