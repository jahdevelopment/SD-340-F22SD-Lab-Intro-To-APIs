var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/", () => "Winnipeg Transit API");

app.Run();
