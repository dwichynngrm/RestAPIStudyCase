using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Dtos
{
    public class CourseForCreateDto : IValidatableObject
    {
        [Required]
        public string CourseName { get; set; }

        [Required]
        public int Credits { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CourseName.Length >= 50)
            {
                yield return new ValidationResult("Course Name maksimal 50 karakter",
                    new[] { "Course Name" });
            }

            if (Credits >= 10)
            {
                yield return new ValidationResult("Credits maksimal 10 karakter",
                    new[] { "Credits" });
            }
        }
    }
}
