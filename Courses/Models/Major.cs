using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Courses.Models
{
    public class Major
    {
        [Key]
        [Display(Name = "Major Id")]
        public byte Id { get; set; }
    }
}