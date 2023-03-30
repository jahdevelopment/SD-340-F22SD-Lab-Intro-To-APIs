using System.ComponentModel.DataAnnotations;

namespace SD_340_F22SD_Lab_Intro_To_APIs.Models
{
    public class Stop
    {
        public int Number { get; set; }

        public string Street { get; set; }

        public string Name { get; set; }

        public Direction Direction { get; set; }

        public virtual List<ScheduledStop> ScheduledStops { get; set; } = new List<ScheduledStop>();

        public Stop() { }

        public Stop(string street, string name, Direction direction)
        {
            Street = street;
            Name = name;
            Direction = direction;
        }   
    }
}
