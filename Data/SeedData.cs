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

            Route routeOne = new Route("Route 1", Direction.North, true, true);
            Route routeTwo = new Route("Route 2", Direction.South, false, false);

            if (!context.Route.Any())
            {
                context.Route.Add(routeOne);
                context.Route.Add(routeTwo);
            }

            Stop stop105N = new Stop("Main St.", "105", Direction.North);
            Stop stop205N = new Stop("Elm St.", "205", Direction.North);
            Stop stop305N = new Stop("Oak St.", "305", Direction.North);
            Stop stop405N = new Stop("Maple St.", "405", Direction.North);
            Stop stop505N = new Stop("Pine St.", "505", Direction.North);
            
            Stop stop505S = new Stop("Pine St.", "505", Direction.South);
            Stop stop405S = new Stop("Maple St.", "405", Direction.South);
            Stop stop305S = new Stop("Oak St.", "305", Direction.South);
            Stop stop205S = new Stop("Elm St.", "205", Direction.South);
            Stop stop105S = new Stop("Main St.", "105", Direction.South);


            if (!context.Stop.Any())
            {
                context.Stop.Add(stop105N);
                context.Stop.Add(stop205N);
                context.Stop.Add(stop305N);
                context.Stop.Add(stop405N);
                context.Stop.Add(stop505N);
                context.Stop.Add(stop505S);
                context.Stop.Add(stop405S);
                context.Stop.Add(stop305S);
                context.Stop.Add(stop205S);
                context.Stop.Add(stop105S);
            }

            ScheduledStop scheduledStopOne = new ScheduledStop(stop105N, routeOne, new DateTime(2023, 3, 27, 9, 0, 0));
            ScheduledStop scheduledStopTwo = new ScheduledStop(stop205N, routeOne, new DateTime(2023, 3, 27, 9, 5, 0));
            ScheduledStop scheduledStopThree = new ScheduledStop(stop305N, routeOne, new DateTime(2023, 3, 27, 9, 10, 0));
            ScheduledStop scheduledStopFour = new ScheduledStop(stop405N, routeOne, new DateTime(2023, 3, 27, 9, 15, 0));
            ScheduledStop scheduledStopFive = new ScheduledStop(stop505N, routeOne, new DateTime(2023, 3, 27, 9, 20, 0));

            ScheduledStop scheduledStopSix = new ScheduledStop(stop505S, routeTwo, new DateTime(2023, 3, 27, 10, 25, 0));
            ScheduledStop scheduledStopSeven = new ScheduledStop(stop405S, routeTwo, new DateTime(2023, 3, 27, 10, 30, 0));
            ScheduledStop scheduledStopEight = new ScheduledStop(stop305S, routeTwo, new DateTime(2023, 3, 27, 10, 35, 0));
            ScheduledStop scheduledStopNine = new ScheduledStop(stop205S, routeTwo, new DateTime(2023, 3, 27, 10, 40, 0));
            ScheduledStop scheduledStopTen = new ScheduledStop(stop105S, routeTwo, new DateTime(2023, 3, 27, 10, 45, 0));

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
