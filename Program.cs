using Microsoft.EntityFrameworkCore;
using SD_340_F22SD_Lab_Intro_To_APIs.Data;
using SD_340_F22SD_Lab_Intro_To_APIs.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WinnipegTransitAPIContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WinnipegTransitAPIContext")));

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;

    await SeedData.Initialize(services);
}



app.MapGet("/", () => "Winnipeg Transit API");



app.MapGet("/Route", async (WinnipegTransitAPIContext context) =>
await context.Route.ToListAsync());

app.MapGet("/Route/{id}", async (int id, WinnipegTransitAPIContext context) =>
await context.Route.FindAsync(id)
    is SD_340_F22SD_Lab_Intro_To_APIs.Models.Route route
    ? Results.Ok(route)
    : Results.BadRequest($"Route {id} was not found"));



app.MapGet("/Stop", async (WinnipegTransitAPIContext context) =>
await context.Stop.ToListAsync());

app.MapGet("/Stop/{number}", (int number, WinnipegTransitAPIContext context) =>
{
    Stop stop = context.Stop.FirstOrDefault(s =>
    s.Number == number);

    if (stop == null)
    {
        return Results.BadRequest($"Stop {number} was not found");
    }
    return Results.Ok(stop);
});


app.MapGet("/ScheduledStop", async (WinnipegTransitAPIContext context) =>
await context.ScheduledStop.ToListAsync());

app.MapGet("/ScheduledStop/topstopnumber", (WinnipegTransitAPIContext context) =>
{
    var topStop = context.ScheduledStop
    .OrderByDescending(ts => ts.Stop.Number)
    .Select(sn => sn.Stop.Number)
    .FirstOrDefault();

    if (topStop == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(topStop);
});

app.Run();
