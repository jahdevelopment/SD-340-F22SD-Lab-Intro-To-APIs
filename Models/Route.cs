using System.ComponentModel.DataAnnotations;

namespace SD_340_F22SD_Lab_Intro_To_APIs.Models
{
    public class Route
    {
        [Key]
        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        public Direction Direction { get; set; }

        public bool RampAccessible { get; set; }

        public bool BicycleAccessible { get; set; }

        public virtual ICollection<ScheduledStop> ScheduledStop { get; set; } = new List<ScheduledStop>();
    }
}
