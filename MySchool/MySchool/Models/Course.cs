using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Models
{
    [Table("COURSE")]
    public class Course
    {
        [Key]
        public int IdCourse { get; set; }
        [Required]
        public String registration { get; set; }
        [Required]
        public String course { get; set; }
        [Required]
        public String classes { get; set; }
        public DateTime horary { get; set; }
    }
}
