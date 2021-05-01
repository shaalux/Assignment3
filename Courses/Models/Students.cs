using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Courses.Models
{
    public class Students
    {
        [Key]
        public byte Id { get; set; }
        
        [Required(ErrorMessage = "The Name Field is Required")]
        [Column(TypeName="nvarchar")]
        [StringLength(60)]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(60)]
        public string LastName { get; set; }
        
        public Admission Admission { get; set; }
        [Column(TypeName =("char"))]
        [StringLength(9)]
        public string AdmissionTermCode { get; set; }

        [Column(TypeName =("DateTime2"))]
        public DateTime DateOfBirth { get; set; }
       
        public Major Major { get; set; }
        public byte MajorId { get; set; }

    }
}