using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentService.Models;

namespace PaymentService.Data
{
    public class EnrollmentDAL : IEnrollment
    {
         private readonly Case1DbContext _db;

        public EnrollmentDAL(Case1DbContext db)
        {
            _db = db;
        }
        public async Task CreateEnrollemnt(Enrollment enrollment)
        {
            if(enrollment == null) throw new ArgumentNullException(nameof(enrollment));
            _db.Enrollments.Add(enrollment);
            await _db.SaveChangesAsync();
        }
    }
}