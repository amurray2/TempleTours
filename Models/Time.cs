using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models
{
    public class Time
    {
        [Key]
        [Required]
        public int TimeId { get; set; }

        [Required]
        public DateTime  TimeDescription { get; set; }

        [Required]
        public bool Available { get; set; }
    }
}
