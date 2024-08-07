using MinimalApi;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new GurameLogProvider());;

var app = builder.Build();

app.MapGet("/", () =>
{
    return TypedResults.Ok();
});

app.Run();