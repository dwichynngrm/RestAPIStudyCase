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
        private IEnrollmentDataClient _dataClient;
        private IEnrollment _enrollment;
        private IMapper _mapper;
        public EnrollmentsController(IEnrollment enrollment, IMapper mapper, IEnrollmentDataClient dataClient)
        {
            _dataClient = dataClient;
            _enrollment = enrollment ?? throw new ArgumentNullException(nameof(enrollment));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<EnrollmentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentDto>>> Get()
        {
            var results = await _enrollment.GetAll();
            return Ok(_mapper.Map<IEnumerable<EnrollmentDto>>(results));
        }


        // GET api/<EnrollmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDto>> Get(int id)
        {
            var result = await _enrollment.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<EnrollmentDto>(result));
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public async Task<ActionResult> EnrollmentCreate(EnrollmentForCreateDto enrollmentForCreateDto)
        {
            try
            {
                await _dataClient.CreateEnrollmentFromPaymentService(enrollmentForCreateDto);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EnrollmentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Enrollment>> Put(int id, [FromBody] EnrollmentForCreateDto enrollmentToCreateDto)
        {
            try
            {
                var enrollment = _mapper.Map<Enrollment>(enrollmentToCreateDto);
                var result = await _enrollment.Update(id.ToString(), enrollment);
                var enrollmentdto = _mapper.Map<EnrollmentDto>(result);
                return Ok(enrollmentdto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EnrollmentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _enrollment.Delete(id.ToString());
                return Ok($"delete data enrollment id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
