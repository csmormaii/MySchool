using Microsoft.EntityFrameworkCore;
using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    IdCourse = 1,
                    registration = "456789",
                    course = "Sistema da Informação",
                    classes = "Sala A1",
                    horary = DateTime.Today
                }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    IdTeacher = 1,
                    name = "Claudio",
                    register = "34567",
                    subjects = "Programação Backend",
                    telephone = "2140028855",
                    IdCourse = 1
                }
            );
        }
    }
}
