using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models.ViewModels
{
    public class AppointmentFormViewModel
    {
        //A view model for the AppointmentSignUpForm
        public Appointment Appointment { get; set; }
        public Time TimeSlot { get; set; }
    }
}
