using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Models
{
    [Table("TEACHER")]
    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }
        [Required]
        [StringLength(250)]
        public String name { get; set; }
        public String subjects { get; set; }
        [Required]
        public String register { get; set; }
        public String telephone { get; set; }
        [Required]
        public int IdCourse { get; set; }
    }
}
