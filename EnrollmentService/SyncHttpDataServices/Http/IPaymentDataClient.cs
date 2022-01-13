using EnrollmentService.Dtos;
using System.Threading.Tasks;
using EnrollmentService.Models;

namespace EnrollmentService.SyncHttpDataServices.Http
{
    public interface IPaymentDataClient
    {
        Task CreateEnrollmentInPayment(EnrollmentDto enrol);

    }
}
