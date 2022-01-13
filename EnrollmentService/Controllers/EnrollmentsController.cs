using AutoMapper;
using EnrollmentService.Data;
using EnrollmentService.Dtos;
using EnrollmentService.Models;
using EnrollmentService.SyncHttpDataServices.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnrollmentService.Controllers
{
    [Authorize(Roles = "admin, student")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IPaymentDataClient _dataClient;
        private IEnrollment _enrollment;
        private IMapper _mapper;
        public EnrollmentsController(IEnrollment enrollment, IMapper mapper, IPaymentDataClient dataClient)
        {
            _dataClient = dataClient;
            _enrollment = enrollment ?? throw new ArgumentNullException(nameof(enrollment));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<EnrollmentsController>
        [HttpGet]
        public ActionResult<IEnumerable<EnrollmentDto>> GetAllEnrollment()
        {
            Console.WriteLine("--> Getting Enrollments .....");
            var results = _enrollment.GetAllEnrollment();
            return Ok(_mapper.Map<IEnumerable<EnrollmentDto>>(results));
        }


        // GET api/<EnrollmentsController>/5
        [HttpGet("{id}")]
        public ActionResult<EnrollmentDto> GetEnrollmentById(int id)
        {
            var result = _enrollment.GetEnrollmentById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<EnrollmentDto>(result));
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public async Task<ActionResult<EnrollmentDto>> CreateEnrollment(EnrollmentForCreateDto enrollmentForCreateDto)
        {
            var enrollmentModel = _mapper.Map<Models.Enrollment>(enrollmentForCreateDto);
            await _enrollment.CreateEnrollment(enrollmentModel);
            _enrollment.SaveChanges();

            var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollmentModel);

            //send sync
            try
            {
                await _dataClient.CreateEnrollmentInPayment(enrollmentDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetEnrollmentById),
            new { Id = enrollmentDto.EnrollmentId }, enrollmentDto);
        }


    }
}
