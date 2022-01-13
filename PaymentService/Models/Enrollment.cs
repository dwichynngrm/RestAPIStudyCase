using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaymentService.Models
{
    public enum Grade
    {
        A, B, C, D, E
    }
    public class Enrollment
    {

        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        public float? InvoicePayment { get; set; }

        [JsonIgnore]
        public Course Course { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
    }
}
