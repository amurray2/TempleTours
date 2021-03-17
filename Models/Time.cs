using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models
{
    public class Time
    {
        //Time model has the time description and the available field tells us if the time is available
        [Key]
        [Required]
        public int TimeId { get; set; }

        [Required]
        public DateTime  TimeDescription { get; set; }

        [Required]
        public bool Available { get; set; }
    }
}
