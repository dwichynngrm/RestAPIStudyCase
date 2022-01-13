using EnrollmentService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnrollmentService.Data
{
    public interface IEnrollment 
    {
        bool SaveChanges();
        IEnumerable<Enrollment> GetAllEnrollment();
        Enrollment GetEnrollmentById(int id);
        Task<Enrollment> CreateEnrollment(Enrollment enrol);

    }
}
