namespace Courses.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Courses.Models.CoursesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Courses.Models.CoursesDbContext context)
        {
            context.Department.AddOrUpdate(a => a.Id,
                new Models.Department() { Id = 1 },
                new Models.Department() { Id = 2 }
                );
            
            context.Major.AddOrUpdate(x => x.Id,
                new Models.Major() { Id = 3 },
                new Models.Major() { Id = 4 }
                );
            
            context.Admission.AddOrUpdate(a => a.TermCode,
                new Models.Admission() { TermCode = "201910" },
                new Models.Admission() { TermCode = "202010" }
                );

            context.Courses.AddOrUpdate(a => a.CourseId,
                new Models.Course() { CourseId= 5,CourseName="CSCI310",Credits=12,DepartmentId=1 },
                new Models.Course() { CourseId = 4, CourseName = "CSCI315", Credits = 15, DepartmentId = 2 }
                );

            context.Students.AddOrUpdate(a => a.Id,
                new Models.Students() {Id = 6, AdmissionTermCode="201910", FirstName="Mohammad",LastName="Shaalan",MajorId=3, DateOfBirth=new DateTime(2019,11,10)},
                new Models.Students() { Id = 7, AdmissionTermCode = "202010", FirstName = "Mohammad", LastName = "Ali", MajorId = 4, DateOfBirth = new DateTime(2019, 11, 10) }
                );

        }
    }
}
