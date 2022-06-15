using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Services
{
    interface CourseServices
    {
        List<Course> GetCourses();
        Teacher GetCourse(int id);
        void AddCourse(Teacher item);
        void UpdateCourse(Teacher item);
        void DeleteCourse(int id);
        bool CourseExists(int id);
    }
}
