using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models
{
    public class TempleTourContext : DbContext
    {
        //Our database context file
        public TempleTourContext(DbContextOptions<TempleTourContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Time> Times { get; set; }
    }
}
