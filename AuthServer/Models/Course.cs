﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AuthServer.Models
{
    public partial class Course
    {
        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        [Required]
        public int Credits { get; set; }


        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}