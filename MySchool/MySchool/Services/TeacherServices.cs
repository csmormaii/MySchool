using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Services
{
    interface TeacherServices
    {
        List<Teacher> GetTeachers();
        Teacher GetTeacher(int id);
        void AddTeacher(Teacher item);
        void UpdateTeacher(Teacher item);
        void DeleteTeacher(int id);
        bool TeacherExists(int id);
    }
}
