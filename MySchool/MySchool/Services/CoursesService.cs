using Microsoft.EntityFrameworkCore;
using MySchool.Context;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Services
{
    public class CoursesService : ICourseService
    {
        private readonly AppDbContext _context;

        public CoursesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            try
            {
                return await _context.Courses.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Course> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            return course;
        }

        public async Task CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourse(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}
