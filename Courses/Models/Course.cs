using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Courses.Models
{
    public class Course
    {
       
        [Key]
        public byte CourseId { get; set; }
        public string CourseName { get; set; }
        [MaximumCreditSize]
        public int Credits { get; set; }
        public Department Department { get; set; }
        public byte DepartmentId { get; set; }

        
    }
}