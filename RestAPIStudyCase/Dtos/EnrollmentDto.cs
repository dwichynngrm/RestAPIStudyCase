
using RestAPIStudyCase.Models;

namespace RestAPIStudyCase.Dtos
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }
       
        public int StudentId { get; set; }
       
        public Grade? Grade { get; set; }
    }
}
