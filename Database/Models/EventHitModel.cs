using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class EventHitModel
    {
        [Key]
        public int Key { get; set; }

        public bool Hit { get; set; }
    }
}
