using AutoMapper;
using EnrollmentService.Data;
using EnrollmentService.Dtos;
using EnrollmentService.Models;
using EnrollmentService.SyncDataServices.Http;
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
        public async Task<ActionResult<IEnumerable<EnrollmentDto>>> Get()
        {
            var enrollments = await _enrollment.GetAll();
            var dtos = _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
            return Ok(dtos);
        }


        // GET api/<EnrollmentsController>/5
        [HttpGet("{id}", Name = "GetEnrollmentById")]
        public async Task<ActionResult<EnrollmentDto>> GetEnrollmentById(int id)
        {
            var result = await _enrollment.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<EnrollmentDto>(result));
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public async Task<ActionResult<EnrollmentDto>> Post([FromBody] EnrollmentForCreateDto enrollmentCreateDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentCreateDto);
            //var result = await _enrollment.Insert(enrollment);
            var dtos = _mapper.Map<EnrollmentDto>(enrollment);

            var post = new EnrollmentForCreateDto
            {
                CourseId = enrollmentCreateDto.CourseId,
                StudentId = enrollmentCreateDto.StudentId,
                InvoicePayment = enrollmentCreateDto.InvoicePayment
            };
            try
            {
                await _dataClient.SendPostAsync(post);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            // return CreatedAtRoute(nameof(GetEnrollmentById),
            // new {Id=dtos.Id},dtos);
            return Ok(dtos);
        }

        // DELETE api/<EnrollmentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _enrollment.Delete(id.ToString());
                return Ok($"Data enrollment {id} berhasil di delete");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
