using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class FeedbackMod
    {
        [Key]
        public int Key { get; set; }

        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
