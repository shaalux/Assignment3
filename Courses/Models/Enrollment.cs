using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Courses.Models
{
    public class Enrollment
    {
        public Students Students { get; set; }
        [Key]
        [Display(Name ="Id")]
        public byte StudentsId { get; set; }

        public Course Course { get; set; }
        
        public byte CourseId { get; set; }
        public Major Major { get; set; }
        
        public byte MajorId { get; set; }

        public Admission Admission { get; set; }
        
        [Column(TypeName = ("char"))]
        [StringLength(9)]
        [Display(Name ="Admission Code")]
        public string AdmissionTermCode { get; set; }

        public int Grade { set; get; }
        
        [Column(TypeName =("bit"))]
        public bool EnrolledIndicator { get; set; }
        [Column(TypeName =("bit"))]
        public bool PaymentIndicator { get; set; }
    }
}