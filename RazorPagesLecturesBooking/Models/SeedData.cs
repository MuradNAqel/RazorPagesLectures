using Microsoft.EntityFrameworkCore;
using RazorPagesLecturesBooking.Data;

namespace RazorPagesLecturesBooking.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesLecturesBookingContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesLecturesBookingContext>>()))
            {
                if (context == null || context.Lecture == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Lecture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Lecture.AddRange(
                    new Lecture
                    {
                        LecturerName = "Seed1",
                        Name = "Name",
                        Capacity = 100,
                        LectureDateAndTime = DateTime.Now,
                        Rating = "Good"
                    },
                    new Lecture
                    {
                        LecturerName = "Seed2",
                        Name = "Name2",
                        Capacity = 100,
                        LectureDateAndTime = DateTime.Now,
                        Rating = "Bad"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
