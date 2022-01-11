using EnrollmentService.Dtos;
using System.Threading.Tasks;
using EnrollmentService.Models;

namespace EnrollmentService.SyncHttpDataServices.Http
{
    public interface IEnrollmentDataClient
    {
        Task CreateEnrollmentFromPaymentService(EnrollmentForCreateDto enrollment);
    }
}
