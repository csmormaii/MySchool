using MySchool.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class Teacher : TeachersViewModels
    {
        public Teacher() { }

        public Teacher(TeachersViewModels _teacher)
        {
            //Id = _teacher.Id;
            name = _teacher.name;
            subjects = _teacher.subjects;
            register = _teacher.register;
            telephone = _teacher.telephone;
        }

        public int Id { get; set; }
        public String name { get; set; }
        public String subjects { get; set; }
        public String register { get; set; }
        public String telephone { get; set; }
    }
}
