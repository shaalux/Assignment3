using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Courses.Models
{
    public class Admission
    {
        [Key]
        [Column(TypeName = ("char"))]
        [StringLength(9)]
        public string TermCode { get; set; }
    }
}