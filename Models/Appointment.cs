using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models
{
    public class Appointment
    {
        //Appointment model, this stores group information and the datetime of the appointment. We get the datetime from the Time model.
        [Key]
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "Please enter a number for the Group Size field")] //In order to have a custom error message for a required integer field you need to make the value nullable.
        public int? GroupSize { get; set; }
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }

        [RegularExpression(@"^\(([0-9]{3})\)-([0-9]{3})-([0-9]{4})$", ErrorMessage = "The Phone Number must match the follwoing format (801)-123-4567")] //use regular expression. Phone must be entered a certain way.
        public string Phone { get; set; }

        [Required]
        public DateTime TimeSlot { get; set; }

    }
}
