namespace Courses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEnrollementTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        StudentsId = c.Byte(nullable: false),
                        CourseId = c.Byte(nullable: false),
                        MajorId = c.Byte(nullable: false),
                        AdmissionTermCode = c.String(maxLength: 9, fixedLength: true, unicode: false),
                        Grade = c.Int(nullable: false),
                        EnrolledIndicator = c.Boolean(nullable: false),
                        PaymentIndicator = c.Boolean(nullable: false),
                        Students_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.StudentsId)
                .ForeignKey("dbo.Admissions", t => t.AdmissionTermCode)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Majors", t => t.MajorId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.CourseId)
                .Index(t => t.MajorId)
                .Index(t => t.AdmissionTermCode)
                .Index(t => t.Students_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "MajorId", "dbo.Majors");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "AdmissionTermCode", "dbo.Admissions");
            DropIndex("dbo.Enrollments", new[] { "Students_Id" });
            DropIndex("dbo.Enrollments", new[] { "AdmissionTermCode" });
            DropIndex("dbo.Enrollments", new[] { "MajorId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropTable("dbo.Enrollments");
        }
    }
}
