﻿

using EnrollmentService.Models;

namespace EnrollmentService.Dtos
{

    public class EnrollmentForCreateDto
    {
     
        public int CourseId { get; set; }
        
        public int StudentId { get; set; }
      
        public Grade? Grade { get; set; }
    }
}
