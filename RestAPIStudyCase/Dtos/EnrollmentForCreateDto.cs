using System.ComponentModel.DataAnnotations;

namespace RestAPIStudyCase.Dtos
{
    
    public class EnrollmentForCreateDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int Grade { get; set; }
    }
}
