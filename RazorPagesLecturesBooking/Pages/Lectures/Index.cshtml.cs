using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesLecturesBooking.Data;
using RazorPagesLecturesBooking.Models;

namespace RazorPagesLecturesBooking.Pages.Lectures
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesLecturesBookingContext _context;

        public IndexModel(RazorPagesLecturesBookingContext context)
        {
            _context = context;
        }

        public IList<Lecture> Lecture { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? LecturerName { get; set; }

        public SelectList? LecturerNames { get; set; } //Key word filter


        //Sarch By Lecturer name And Or Course name
        public async Task OnGetAsync()
        {
            var lecturersQuery = from ln in _context.Lecture
                                 orderby ln.LecturerName
                                 select ln.LecturerName;

            var Lectures = from lect in _context.Lecture
                           select lect;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Lectures = Lectures.Where(l => l.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(LecturerName))
            {
                Lectures = Lectures.Where(l => l.LecturerName.Contains(LecturerName));
            }

            LecturerNames = new SelectList(await lecturersQuery.Distinct().ToListAsync());

            Lecture = await Lectures.ToListAsync();
        }

        //public async Task OnGetAsync()
        //{
        //    Lecture = await _context.Lecture.ToListAsync();
        //}

        // Search By Name
        //public async Task OnGetAsync()
        //{
        //    var courseNames = from cn in _context.Lecture
        //                      select cn;
        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        courseNames = courseNames.Where(cn => cn.Name.Contains(SearchString));
        //    }

        //    Lecture = await courseNames.ToListAsync();
        //}

    }
}
