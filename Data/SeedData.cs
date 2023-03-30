using Microsoft.EntityFrameworkCore;
using SD_340_F22SD_Lab_Intro_To_APIs.Models;
using Route = SD_340_F22SD_Lab_Intro_To_APIs.Models.Route;

namespace SD_340_F22SD_Lab_Intro_To_APIs.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            WinnipegTransitAPIContext context = new WinnipegTransitAPIContext(serviceProvider.GetRequiredService<DbContextOptions<WinnipegTransitAPIContext>>());

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            Route routeOne = new Route("Route 1", Direction.South, true, true);
            Route routeTwo = new Route("Route 2", Direction.North, false, false);

            if (!context.Route.Any())
            {
                context.Route.Add(routeOne);
                context.Route.Add(routeTwo);
            }

            Stop stopOne = new Stop( "Main St.", "Stop 101", Direction.North);
            Stop stopTwo = new Stop("Elm St.", "Stop 102", Direction.South);
            Stop stopThree = new Stop("Oak St.", "Stop 103", Direction.Northeast);
            Stop stopFour = new Stop("Maple St.", "Stop 104", Direction.Southeast);
            Stop stopFive = new Stop("Pine St.", "Stop 105", Direction.Southwest);

            if (!context.Stop.Any())
            {
                context.Stop.Add(stopOne);
                context.Stop.Add(stopTwo);
                context.Stop.Add(stopThree);
                context.Stop.Add(stopFour);
                context.Stop.Add(stopFive);
            }

            ScheduledStop scheduledStopOne = new ScheduledStop(stopOne, routeOne, new DateTime(2023, 3, 27, 9, 0, 0));
            ScheduledStop scheduledStopTwo = new ScheduledStop(stopTwo, routeOne, new DateTime(2023, 3, 27, 9, 5, 0));
            ScheduledStop scheduledStopThree = new ScheduledStop(stopThree, routeOne, new DateTime(2023, 3, 27, 9, 10, 0));
            ScheduledStop scheduledStopFour = new ScheduledStop(stopFour, routeOne, new DateTime(2023, 3, 27, 9, 15, 0));
            ScheduledStop scheduledStopFive = new ScheduledStop(stopFive, routeOne, new DateTime(2023, 3, 27, 9, 20, 0));

            ScheduledStop scheduledStopSix = new ScheduledStop(stopOne, routeTwo, new DateTime(2023, 3, 27, 10, 25, 0));
            ScheduledStop scheduledStopSeven = new ScheduledStop(stopTwo, routeTwo, new DateTime(2023, 3, 27, 10, 30, 0));
            ScheduledStop scheduledStopEight = new ScheduledStop(stopThree, routeTwo, new DateTime(2023, 3, 27, 10, 35, 0));
            ScheduledStop scheduledStopNine = new ScheduledStop(stopFour, routeTwo, new DateTime(2023, 3, 27, 10, 40, 0));
            ScheduledStop scheduledStopTen = new ScheduledStop(stopFive, routeTwo, new DateTime(2023, 3, 27, 10, 45, 0));

            if (!context.ScheduledStop.Any())
            {
                context.ScheduledStop.Add(scheduledStopOne);
                context.ScheduledStop.Add(scheduledStopTwo);
                context.ScheduledStop.Add(scheduledStopThree);
                context.ScheduledStop.Add(scheduledStopFour);
                context.ScheduledStop.Add(scheduledStopFive);
                context.ScheduledStop.Add(scheduledStopSix);
                context.ScheduledStop.Add(scheduledStopSeven);
                context.ScheduledStop.Add(scheduledStopEight);
                context.ScheduledStop.Add(scheduledStopNine);
                context.ScheduledStop.Add(scheduledStopTen);
            }
            
            await context.SaveChangesAsync();
        }
    }
}
