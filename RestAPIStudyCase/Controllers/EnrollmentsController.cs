using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPIStudyCase.Data;
using RestAPIStudyCase.Dtos;
using RestAPIStudyCase.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPIStudyCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IEnrollment _enrollment;
        private IMapper _mapper;
        public EnrollmentsController(IEnrollment enrollment, IMapper mapper)
        {
            _enrollment = enrollment ?? throw new ArgumentNullException(nameof(enrollment));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<EnrollmentsController>
        [HttpGet]
        public async Task<IEnumerable<Enrollment>> Get()
        {
            var results = await _enrollment.GetAll();
            return results;
        }

        // GET api/<EnrollmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetById(int id)
        {
            var result = await _enrollment.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public async Task<ActionResult<Enrollment>> Post([FromBody] EnrollmentForCreateDto enrollmentforCreateDto)
        {
            try
            {
                var enrollment = _mapper.Map<Models.Enrollment>(enrollmentforCreateDto);
                var result = await _enrollment.Insert(enrollment);
                return Ok(result);
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
                var course = _mapper.Map<Models.Enrollment>(enrollmentToCreateDto);
                var result = await _enrollment.Update(id.ToString(), course);
                return Ok(result);
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
                return Ok($"delete data id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
