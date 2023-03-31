using System.ComponentModel.DataAnnotations;

namespace SD_340_F22SD_Lab_Intro_To_APIs.Models
{
    public class Route
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public Direction Direction { get; set; }

        public bool RampAccessible { get; set; }

        public bool BicycleAccessible { get; set; }

        public virtual List<ScheduledStop> ScheduledStops { get; set; } = new List<ScheduledStop>();

        public Route() { }

        public Route(string name, Direction direction, bool rampAccessible, bool byclicleAccessible) 
        {
            Name = name;
            Direction = direction;
            RampAccessible = rampAccessible;
            BicycleAccessible = byclicleAccessible;
        }
    }
}
