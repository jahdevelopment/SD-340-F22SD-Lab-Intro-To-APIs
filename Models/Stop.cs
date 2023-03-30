using System.ComponentModel.DataAnnotations;

namespace SD_340_F22SD_Lab_Intro_To_APIs.Models
{
    public class Stop
    {
        [Key]
        public int Number { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Name { get; set; }

        public Direction Direction { get; set; }

        public virtual List<ScheduledStop> ScheduledStops { get; set; } = new List<ScheduledStop>();
    }
}
