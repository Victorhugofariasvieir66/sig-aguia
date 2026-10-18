using Microsoft.EntityFrameworkCore;
using SigAguia.Infrastructure.Persistence;
using SigAguia.Application.Unidades.CriarUnidade;
using SigAguia.Application.Unidades.Repositories;
using SigAguia.Infrastructure.Repositories;
using SigAguia.Application.Unidades.ListarUnidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("SigAguia")
    ?? throw new InvalidOperationException(
        "Connection string 'SigAguia' não configurada.");

builder.Services.AddDbContext<SigAguiaDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();
builder.Services.AddScoped<CriarUnidadeHandler>();
builder.Services.AddScoped<ListarUnidadesHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm",
    "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    return forecast;
})
.WithName("GetWeatherForecast");

app.MapPost("/unidades", async (
    CriarUnidadeCommand command,
    CriarUnidadeHandler handler,
    CancellationToken cancellationToken) =>
{
    try
    {
        var resultado = await handler.ExecutarAsync(
            command,
            cancellationToken);

        return Results.Created(
            $"/unidades/{resultado.Id}",
            resultado);
    }
    catch (NomeUnidadeInvalidoException exception)
    {
        return Results.BadRequest(new
        {
            mensagem = exception.Message
        });
    }
    catch (MatrizJaExisteException exception)
    {
        return Results.Conflict(new
        {
            mensagem = exception.Message
        });
    }
});
app.MapGet("/unidades", async (
    ListarUnidadesHandler handler,
    CancellationToken cancellationToken) =>
{
    var resultado = await handler.ExecutarAsync(cancellationToken);

    return Results.Ok(resultado);
});
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}