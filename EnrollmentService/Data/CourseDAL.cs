﻿using EnrollmentService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentService.Data
{
    public class CourseDAL : ICourse
    {
        private ApplicationDbContext _db;
        public CourseDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Delete(string id)
        {
            try
            {
                var result = await GetById(id);
                if (result == null) throw new Exception($"data course {id} tidak ditemukan");
                _db.Courses.Remove(result);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"error: {dbEx.Message}");
            }

        }


        public async Task<IEnumerable<Course>> GetAll()
        {
            var results = await (from s in _db.Courses
                                 orderby s.CourseName ascending
                                 select s).ToListAsync();
            return results;
        }

        public async Task<Course> GetById(string id)
        {
            var result = await _db.Courses.Where(s => s.CourseId == Convert.ToInt32(id)).SingleOrDefaultAsync();
            if (result != null)
                return result;
            else
                throw new Exception("Data tidak ditemukan !");
        }

        public async Task<IEnumerable<Course>> GetByCourseName(string name)
        {
            var results = await (from c in _db.Courses
                                 where c.CourseName.ToLower().Contains(name.ToLower())
                                 orderby c.CourseName ascending
                                 select c).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Course> Insert(Course obj)
        {
            try
            {
                _db.Courses.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public async Task<Course> Update(string id, Course obj)
        {
            try
            {
                var result = await GetById(id);
                if (result == null) throw new Exception($"data course id {id} tidak ditemukan");
                result.CourseName = obj.CourseName;
                result.Credits = obj.Credits;
                await _db.SaveChangesAsync();
                return result;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

    }
}
