using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleTours.Models;

namespace TempleTours.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TempleTourContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, TempleTourContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult TimeSlots()//need to pass in all of the available time slots
        {
            return View(context.Times
                .Where(t => t.Available == true)
                );
        }

        [HttpGet]
        public IActionResult SignUpForm(Time time) //The appointment time needs to be passed into the SignUpForm page when a button is selected from the TimeSlots page. This happens with Get?
        {
            return View(time);
        }
        [HttpPost]
        public IActionResult SignUpForm(Appointment appointment) //The post method for this form collects the appointment information added and saves it to the context.
        {
            if (ModelState.IsValid)
            {
                context.Appointments.Add(appointment);
                context.SaveChanges();
                //At this point, we need to figure out how to take the time slot away that was used for the appointment
                //Maybe something like this:
                //context.Times.RemoveAll(t => t.Times.TimeID == context.Times.TimeId);
                //Or
                //context.Times
                    //.Where(t=> t.TimeId == appointment.TimeSlot)
                    //.Update(t => t.Times.Available = false)
            }
            return View("Index"); //redirects to the home page when submitted
        }


        public IActionResult Appointments() //This will return the Appointments view. This page will list all of the appointments that have been made
        {
            return View(context.Appointments);
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
