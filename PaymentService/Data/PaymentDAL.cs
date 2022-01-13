using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentService.Models;

namespace PaymentService.Data
{
    public class PaymentDAL : IPayment
    {
         private ApplicationDbContext _db;

        public PaymentDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateEnrollemnt(Enrollment enrollment)
        {
            if (enrollment == null) throw new ArgumentNullException(nameof(enrollment));
            _db.Enrollments.Add(enrollment);
            await _db.SaveChangesAsync();
        }

        public async Task<Enrollment> GetById(int id)
        {
            var result = await(from c in _db.Enrollments
                               where c.StudentId == id
                               select c).SingleOrDefaultAsync();
            if (result == null) throw new Exception($"Data id {id} tidak ditemukan !");

            return result;
        }

        public async Task<IEnumerable<Student>> GetTagihan(string name)
        {
            var results = await(from a in _db.Students.Include(e => e.Enrollments)
                                where a.FirstName.ToLower().Contains(name.ToLower())
                                || a.LastName.ToLower().Contains(name.ToLower()) 
                                orderby a.StudentId ascending
                                select a).ToListAsync();
            return results;
        }

     
    }
}