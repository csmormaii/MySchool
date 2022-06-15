using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Api
{
    public class CourseInputModel
    {
        private int Id { get; set; }
        public String registration { get; set; }
        public String course { get; set; }
        public String classes { get; set; }
        public DateTime horary { get; set; }
    }
}
