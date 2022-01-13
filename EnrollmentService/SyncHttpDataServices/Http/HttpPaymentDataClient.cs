
using EnrollmentService.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EnrollmentService.SyncHttpDataServices.Http
{
    public class HttpPaymentDataClient : IPaymentDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        

        public HttpPaymentDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

       

        public async Task CreateEnrollmentInPayment(EnrollmentDto enrol)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(enrol),
                Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_configuration["PaymentService"], httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Successful Sync Post to Payment Service -->");
            }
            else
            {
                Console.WriteLine("--> Failed Sync Post to Payment Service -->");
            }
        }
    }
}
