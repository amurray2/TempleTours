using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleTours.Models;
using TempleTours.Models.ViewModels;

namespace TempleTours.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TempleTourContext context { get; set; } //set up the context as an object of type TempleTourContext (which inherits from the DbContext and has two DbSets as properties)

        public HomeController(ILogger<HomeController> logger, TempleTourContext con)
        {
            _logger = logger;
            context = con; //sets the context
        }

        public IActionResult Index() //returns the home page
        {
            return View();
        }


        public IActionResult TimeSlots()//passes in all of the available time slots
        {
            return View(context.Times.Where(t => t.Available == true));
        }

        [HttpGet]
        public IActionResult SignUpForm(int timeId) //Passes in the time that was selected
        {
            return View(new AppointmentFormViewModel { 
                TimeSlot = context.Times.Single(t => t.TimeId == timeId)
            });
        }

        [HttpPost]
        public IActionResult SignUpForm(AppointmentFormViewModel a, int timeId) //Adds a new appointment to the database and marks the time slot used by that appointment as unavailable
        {
            if (ModelState.IsValid)
            {
                context.Times.Single(t => t.TimeId == timeId).Available = false;
                context.Appointments.Add(a.Appointment);
                context.SaveChanges();
                return RedirectToAction("Index"); //redirects to the home page
            }
            else
            {
                return View(new AppointmentFormViewModel
                {
                    TimeSlot = context.Times.Single(t => t.TimeId == timeId)
                });
            }
        }

        public IActionResult Appointments() //passes in all of the appointment data.
        {
            return View(context.Appointments);
        }
    }
}
