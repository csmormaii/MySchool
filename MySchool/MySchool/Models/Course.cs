using MySchool.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class Course : CoursesViewModels
    {
        public Course() { }
        
        public Course(CoursesViewModels _course)
        {
            registration = _course.registration;
            course = _course.course;
            classes = _course.classes;
            horary = _course.horary;
        }

        public int Id { get; set; }
        public String registration { get; set; }
        public String course { get; set; }
        public String classes { get; set; }
        public DateTime horary { get; set; }
    }
}
