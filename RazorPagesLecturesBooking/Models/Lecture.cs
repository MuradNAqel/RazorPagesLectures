using System.ComponentModel.DataAnnotations;

namespace RazorPagesLecturesBooking.Models
{
    public class Lecture
    {
        //All properties are required by default
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(30, MinimumLength = 6)] //Data Annotatuin to support VAlidation across all the app 
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")] //So that white space is not permittedadd
        [Display(Name = "Lecturer Name")]
        public string LecturerName { get; set; }

        [Display(Name = "Lecture date and time")]
        public DateTime LectureDateAndTime { get; set; }

        public int Capacity { get; set; }

        public string Rating { get; set; } = string.Empty;
    }
}
