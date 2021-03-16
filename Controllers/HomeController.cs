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
<<<<<<< HEAD
            return View(context.Times);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
=======

            return View(context.Times.Where(t => t.Available == true));
        
        }

        [HttpGet]
        public IActionResult SignUpForm(int timeId)
        {
            return View(new AppointmentFormViewModel { 
                TimeSlot = context.Times.Single(t => t.TimeId == timeId)
            });
        }

        [HttpPost]
        public IActionResult SignUpForm(AppointmentFormViewModel a, int timeId)
        {
            if(ModelState.IsValid)
            {
                context.Times.Single(t => t.TimeId == timeId).Available = false;
                context.Appointments.Add(a.Appointment);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(new AppointmentFormViewModel
                {
                    TimeSlot = context.Times.Single(t => t.TimeId == timeId)
                });
            }
            return View(context.Times
                .Where(t => t.Available == true)
                );
>>>>>>> 24ebae63bde81bba326070640f6a0c9e005dbf0b
    }
}
