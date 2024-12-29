using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesLecturesBooking.Models;

namespace RazorPagesLecturesBooking.Data
{
    public class RazorPagesLecturesBookingContext : DbContext
    {
        public RazorPagesLecturesBookingContext (DbContextOptions<RazorPagesLecturesBookingContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesLecturesBooking.Models.Lecture> Lecture { get; set; } = default!;
    }
}
