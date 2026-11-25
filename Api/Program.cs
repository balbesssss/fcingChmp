var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();


app.UseHttpsRedirection();

app.MapGet("/users", () =>
{
    System.Console.WriteLine("""sd""");
    var obj = new Dictionary<string, string>
    {
        ["Id"] = "4",
        ["Name"] = "3424"
    };
    return new List<Dictionary<string, string>>{obj};
})
.WithName("GetWeatherForecast");

app.Run();
