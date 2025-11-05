var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/healthz", () => "OK");

string[] summaries = { "Cool", "Warm", "Hot" };
app.MapGet("/weather", () =>
    Enumerable.Range(1, 5).Select(i => new {
        Date = DateTime.Now.AddDays(i),
        TempC = Random.Shared.Next(-20, 55),
        Summary = summaries[Random.Shared.Next(summaries.Length)]
    }));

app.Run();
