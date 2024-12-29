using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesLecturesBooking.Data;
using RazorPagesLecturesBooking.Models;

namespace RazorPagesLecturesBooking.Pages.Lectures
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesLecturesBooking.Data.RazorPagesLecturesBookingContext _context;

        public EditModel(RazorPagesLecturesBooking.Data.RazorPagesLecturesBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lecture Lecture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture =  await _context.Lecture.FirstOrDefaultAsync(m => m.Id == id);
            if (lecture == null)
            {
                return NotFound();
            }
            Lecture = lecture;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lecture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureExists(Lecture.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LectureExists(int id)
        {
            return _context.Lecture.Any(e => e.Id == id);
        }
    }
}
