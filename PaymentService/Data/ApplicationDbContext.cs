using Microsoft.EntityFrameworkCore;
using PaymentService.Models;

namespace PaymentService.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
       

    }
}
