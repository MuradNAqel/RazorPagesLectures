using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLecturesBooking.Models;

namespace RazorPagesLecturesBooking.Pages.Lectures
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesLecturesBooking.Data.RazorPagesLecturesBookingContext _context;

        public CreateModel(RazorPagesLecturesBooking.Data.RazorPagesLecturesBookingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lecture Lecture { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Lecture.Add(Lecture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
