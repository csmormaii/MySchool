using Microsoft.EntityFrameworkCore;
using MySchool.Context;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Services
{
    public class TeachersService : ITeacherService
    {
        private readonly AppDbContext _context;

        public TeachersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            try
            {
                return await _context.Teachers.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Teacher> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            return teacher;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersByName(string nome)
        {
            IEnumerable<Teacher> teachers;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                teachers = await _context.Teachers.Where(n => n.name.Contains(nome)).ToListAsync();
            }
            else 
            {
                teachers = await GetTeachers();
            }
            return teachers;
        }

        public async Task CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacher(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
