namespace EnrollmentService.Models
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


        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}
