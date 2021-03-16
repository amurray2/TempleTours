using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models.ViewModels
{
    public class AppointmentFormViewModel
    {
        public Appointment Appointment { get; set; }
        public Time TimeSlot { get; set; }
    }
}
