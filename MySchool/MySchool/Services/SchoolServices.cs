using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Services
{
    public class SchoolServices
    {
        private readonly List<Teacher> teachers;
        private readonly List<Course> courses;

        public SchoolServices()
        {
            this.teachers = new List<Teacher>
            {
                new Teacher { name = "Claudio", subjects = "Programação WEB", register = "2345", telephone = "2143215678" },
                new Teacher { name = "Marcelo", subjects = "Programação JAVA", register = "3456", telephone = "2143215678" },
            };

            this.courses = new List<Course>
            {
                new Course { registration = "54321", classes = "A1", course = "Sistema da Informaçãp", horary=DateTime.Today },
                new Course { registration = "55432", classes = "A2", course = "Analista de Sistemas", horary=DateTime.Today },
            };
        }

        public void AddTeacher(Teacher item)
        {
            this.teachers.Add(item);
        }

        public void AddCourse(Course item)
        {
            this.courses.Add(item);
        }

        public void DeleteTeacher(int id)
        {
            var model = this.teachers.Where(m => m.Id == id).FirstOrDefault();
            this.teachers.Remove(model);
        }
        public void DeleteCourse(int id)
        {
            var model = this.courses.Where(m => m.Id == id).FirstOrDefault();
            this.courses.Remove(model);
        }

        public bool TeacherExists(int id)
        {
            return this.teachers.Any(m => m.Id == id);
        }
        public bool CourseExists(int id)
        {
            return this.courses.Any(m => m.Id == id);
        }

        public Teacher GetTeacher(int id)
        {
            return this.teachers.Where(m => m.Id == id).FirstOrDefault();
        }
        public Teacher GetCourse(int id)
        {
            return this.courses.Where(m => m.Id == id).FirstOrDefault();
        }

        public List<Teacher> GetTeachers()
        {
            return this.teachers.ToList();
        }
        public List<Course> GetCourses()
        {
            return this.courses.ToList();
        }

        public void UpdateTeacher(Teacher item)
        {
            var model = this.teachers.Where(m => m.Id == item.Id).FirstOrDefault();

            model.Titulo = item.Titulo;
            model.AnoLancamento = item.AnoLancamento;
            model.Resumo = item.Resumo;
        }

        public void UpdateCourse(Course item)
        {
            var model = this.courses.Where(m => m.Id == item.Id).FirstOrDefault();

            model.Titulo = item.Titulo;
            model.AnoLancamento = item.AnoLancamento;
            model.Resumo = item.Resumo;
        }
    }
}
