using EnrollmentService.Models;
using System;
using System.Linq;

namespace EnrollmentService.Data
{
    public static class DbInitializer
    {

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{FirstName ="Dwi", LastName="Cahyaningrum",EnrollmentDate=DateTime.Parse("2022-01-10")},
                new Student{FirstName ="Agus", LastName="Kurniawan",EnrollmentDate=DateTime.Parse("2022-01-10")},
                new Student{FirstName ="Peter", LastName="Parker",EnrollmentDate=DateTime.Parse("2022-01-10")},
                new Student{FirstName ="Tony", LastName="Stark",EnrollmentDate=DateTime.Parse("2022-01-10")},
                new Student{FirstName ="Bruce", LastName="Banner",EnrollmentDate=DateTime.Parse("2022-01-10")}

            };
            foreach (var s in students)
            {
                context.Students.Add(s);
            }

            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseName="Cloud Fundamentals",Credits=5},
                new Course{CourseName="Microservices Architecture",Credits=2},
                new Course{CourseName="Frontend Progamming",Credits=3},
                new Course{CourseName="Backend RESTful API",Credits=1},
                new Course{CourseName="Entity Framework Coe",Credits=2}
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentId=1,CourseId=1,Grade=Grade.A},
                new Enrollment{StudentId=1,CourseId=2,Grade=Grade.B},
                new Enrollment{StudentId=1,CourseId=3,Grade=Grade.C},
                new Enrollment{StudentId=2,CourseId=1,Grade=Grade.C},
                new Enrollment{StudentId=2,CourseId=2,Grade=Grade.C},
                new Enrollment{StudentId=2,CourseId=3,Grade=Grade.C},
                new Enrollment{StudentId=3,CourseId=1,Grade=Grade.A},
                new Enrollment{StudentId=3,CourseId=2,Grade=Grade.B},
                new Enrollment{StudentId=3,CourseId=3,Grade=Grade.C }
            };

            foreach (var e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();

        }
    }

}
