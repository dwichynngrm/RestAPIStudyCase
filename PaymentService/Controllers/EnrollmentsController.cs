using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Data;
using PaymentService.Dtos;
using PaymentService.Models;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private IPayment _payment;
        private IMapper _mapper;
        private HttpClient _httpClient;
        private IConfiguration _configuration;

        public EnrollmentsController(IPayment payment, IMapper mapper,
            HttpClient httpClient, IConfiguration configuration)
        {
            _payment = payment;
            _mapper = mapper;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEnrollment(EnrollmentCreateDto enrollment)
        {
            try
            {
                var enroll = _mapper.Map<Enrollment>(enrollment);
                await _payment.CreateEnrollemnt(enroll);
                return Ok($"Data enrollment StudentId: {enrollment.StudentId} dan CourseId: {enrollment.CourseId} berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}