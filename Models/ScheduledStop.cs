using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SD_340_F22SD_Lab_Intro_To_APIs.Models
{
    public class ScheduledStop
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StopNumber")]
        public virtual Stop Stop { get; set; }

        public int StopNumber { get; set; }

        public Route Route { get; set; }

        [ForeignKey("RouteNumber")]
        public int RouteNumber { get; set; }

        public DateTime ScheduledArrival { get; set; }
    }
}
