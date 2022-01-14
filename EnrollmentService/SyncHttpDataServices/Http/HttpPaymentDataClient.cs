
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EnrollmentService.Dtos;
using EnrollmentService.SyncDataServices.Http;
using Microsoft.Extensions.Configuration;
namespace EnrollmentService.SyncHttpDataServices.Http
{
    public class HttpPaymentDataClient : IPaymentDataClient
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpPaymentDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task CreateEnrollmentFromPaymentService(EnrollmentForCreateDto enrollment)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(enrollment),
                Encoding.UTF8, "application/json"
            );

            var response = await _httpClient.PostAsync(_configuration["PaymentService"], httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync Post to Payment Service Success -->");
            }
            else
            {
                Console.WriteLine("--> Sync Post to Payment Service Failed -->");
            }
        }


    }
}
