using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
        [Required]
        public int Credits { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
