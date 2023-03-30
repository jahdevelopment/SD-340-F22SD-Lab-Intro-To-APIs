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

app.Run();
