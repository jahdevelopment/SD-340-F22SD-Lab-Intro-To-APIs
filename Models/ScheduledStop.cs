using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SD_340_F22SD_Lab_Intro_To_APIs.Models
{
    public class ScheduledStop
    {
        public int Id { get; set; }

        public virtual Stop Stop { get; set; }

        public int StopNumber { get; set; }

        public Route Route { get; set; }

        public int RouteNumber { get; set; }

        public DateTime ScheduledArrival { get; set; }

        public ScheduledStop() { }

        public ScheduledStop(Stop stop, Route route, DateTime scheduledArrival)
        {
            Stop = stop;
            StopNumber = stop.Number;
            Route = route;
            RouteNumber = route.Number;
            ScheduledArrival = scheduledArrival;
        }
    }
}
