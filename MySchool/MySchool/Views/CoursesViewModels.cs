using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Views
{
    public class CoursesViewModels
    {
        private int Id { get; set; }
        public String registration { get; set; }
        public String course { get; set; }
        public String classes { get; set; }
        public DateTime horary { get; set; }
    }
}
