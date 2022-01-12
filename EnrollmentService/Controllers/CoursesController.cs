﻿using AutoMapper;
using EnrollmentService.Data;
using EnrollmentService.Dtos;
using EnrollmentService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnrollmentService.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;

        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course ?? throw new ArgumentNullException(nameof(course));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: api/<CoursesController>

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var results = await _course.GetAll();
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(results));
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CourseDto>(result));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseForCreateDto courseForCreateDto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseForCreateDto);
                var result = await _course.Insert(course);
                var coursedto = _mapper.Map<CourseDto>(result);
                return Ok(coursedto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseForCreateDto courseToCreateDto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseToCreateDto);
                var result = await _course.Update(id.ToString(), course);
                var coursedto = _mapper.Map<CourseDto>(result);
                return Ok(coursedto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"delete data course id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bycoursename")]
        public async Task<IEnumerable<Course>> GetByCourseName(string coursename)
        {
            var results = await _course.GetByCourseName(coursename);
            return results;
        }
    }
}
