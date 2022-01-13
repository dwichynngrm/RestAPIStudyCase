using PaymentService.Models;

namespace PaymentService.Dtos
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        public float? InvoicePayment { get; set; }
    }
}
