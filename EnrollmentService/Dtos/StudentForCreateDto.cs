using EnrollmentService.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Dtos
{
    [StudentFirstLastMustBeDifferent]
    public class StudentForCreateDto
    {
        [Required(ErrorMessage = "Kolom First Name harus diisi")]
        [MaxLength(20, ErrorMessage = "Tidak boleh lebih dari 20 karakter")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Kolom Last Name harus diisi")]
        [MaxLength(20, ErrorMessage = "Tidak bolej lebih dari 20 karakter")]
        public string LastName { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
}
