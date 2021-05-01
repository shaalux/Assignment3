using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Courses.Models
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext() : base("CoursesConnection")
        {

        }

    public DbSet <Students> Students { get; set; }
    public DbSet <Course> Courses { get; set; }
    public DbSet <Department> Department { get; set; }
    public DbSet<Major> Major { get; set; }
    public DbSet<Admission> Admission { get; set; }

    public DbSet<Enrollment> Enrollment { get; set; }



    }
}