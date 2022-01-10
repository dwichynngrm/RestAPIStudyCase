using RestAPIStudyCase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPIStudyCase.Data
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByCourseName(string coursename);
    }
}
