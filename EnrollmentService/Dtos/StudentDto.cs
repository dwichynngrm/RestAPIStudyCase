﻿using System;

namespace EnrollmentService.Dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
